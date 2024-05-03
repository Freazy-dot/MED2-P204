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

    private Dictionary<string, GameObject> _doors;
    private Dictionary<string, HashSet<string>> _colourIdFinished;
    private Dictionary<string, bool> _colourFinished;

    public bool isPuzzleSolved = false;

    private void Start()
    {
        timer = GameObject.FindObjectOfType<Timer>();
        timer.OnTimerDone += resetColour;

        _doors = new Dictionary<string, GameObject>() {
            {"Red", redDoor},
            {"Blue", blueDoor},
            {"Yellow", yellowDoor}
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

        // add failed sfx here
        _currentColour = null;
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
        }

        if (_currentColour == null) {
            Debug.LogWarning("No current colour");
            return;
        }

        if (_currentColour != colour) {
            Debug.Log("Wrong colour");

            // add wrong press sfx here
            return;
        }
        
        if (_colourFinished[colour] == true) {
            Debug.Log(colour + " already finished");

            // add wrong press sfx here
            return;
        }

        if (_colourIdFinished[colour].Contains(buttonId)) {
            Debug.Log("Button already pressed");

            // add wrong press sfx here
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

            // add correct sound sfx here
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
