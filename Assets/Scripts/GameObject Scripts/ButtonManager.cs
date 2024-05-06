using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ButtonManager : MonoBehaviour
{
    Timer timer;

    private string _currentColour;

    public GameObject redDoor;
    public GameObject blueDoor;
    public GameObject yellowDoor;

    public GameObject redLight;
    public GameObject blueLight;
    public GameObject yellowLight;

    private Dictionary<string, GameObject> _doors;
    private Dictionary<string, GameObject> _lights;
    private Dictionary<string, HashSet<string>> _colourIdFinished;
    private Dictionary<string, bool> _colourFinished;

    SoundManager Soundman;

    public bool isPuzzleSolved = false;

    private void Start()
    {
        timer = GameObject.FindObjectOfType<Timer>();
        timer.onTimerDone += resetColour;

        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();

        _doors = new Dictionary<string, GameObject>() {
            {"Red", redDoor},
            {"Blue", blueDoor},
            {"Yellow", yellowDoor}
        };

        _lights = new Dictionary<string, GameObject>() {
            {"Red", redLight},
            {"Blue", blueLight},
            {"Yellow", yellowLight}
        };

        _colourIdFinished = new Dictionary<string, HashSet<string>>() {
            {"Red", new HashSet<string>()},
            {"Blue", new HashSet<string>()},
            {"Yellow", new HashSet<string>()}
        };

        _colourFinished = new Dictionary<string, bool>() {
            {"Red", false},
            {"Blue", false},
            {"Yellow", false}
        };
    }

    private void resetColour()
    {
        if (_colourFinished[_currentColour] == false) {
            _colourIdFinished[_currentColour].Clear();
        }
        Soundman.playSFX("KeyCode_wrong");
        _currentColour = null;
        changeLight(_currentColour);
    }

    private void changeLight(string colour)
    {
        foreach (var light in _lights.Values) {
                light.SetActive(false);
            }

        if (colour == null) return;

        _lights[colour].SetActive(true);
    }

    public void HandleButtonPress(GameObject player, string colour, string buttonId)
    {   
        if (isPuzzleSolved) {
            Debug.Log("Puzzle already solved");
            return;
        }
        
        // current colour becomes null when timer runs out or when colour is finished
        if (_currentColour == null && _colourFinished[colour] == false) { 
            _currentColour = colour;
            changeLight(_currentColour);
        }

        if (_currentColour == null) {
            Debug.LogWarning("No current colour");
            return;
        }

        if (_currentColour != colour) {
            Debug.Log("Wrong colour");

            Soundman.playSFX("KeyCode_wrong");
            return;
        }
        
        if (_colourFinished[colour] == true) {
            Debug.Log(colour + " already finished");

            Soundman.playSFX("KeyCode_wrong");
            return;
        }

        if (_colourIdFinished[colour].Contains(buttonId)) {
            Debug.Log("Button already pressed");

            Soundman.playSFX("KeyCode_wrong");
            return;
        }

        _colourIdFinished[colour].Add(buttonId);

        if (_colourIdFinished[colour].Count == 3) {
            _colourFinished[colour] = true;
            timer.StopTimer();
            resetColour();
            isPuzzleSolvedCheck();
            openDoor(colour);
            Debug.Log(colour + " finished");

            Soundman.playSFX("KeyCode_right");
            return;
        }

        timer.ResetTimer();
    }

    private void isPuzzleSolvedCheck()
    {
        if (_colourFinished.Values.All(x => x)) {
            isPuzzleSolved = true;

            timer.OnPuzzleDone();
        }
    }

    private void openDoor(string colour)
    {
        IPowerable powerable = _doors[colour].gameObject.GetComponent<IPowerable>();
        powerable.PowerOn();
    }
}
