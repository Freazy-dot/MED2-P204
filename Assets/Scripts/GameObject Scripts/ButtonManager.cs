using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ButtonManager : MonoBehaviour
{
    Timer timer;

    private string _currentColour;
    public string currentColour => _currentColour;

    private Dictionary<string, HashSet<string>> _colourIdFinished = new Dictionary<string, HashSet<string>>(){
        {"Red", new HashSet<string>()},
        {"Blue", new HashSet<string>()},
        {"Yellow", new HashSet<string>()}};
    private Dictionary<string, bool> _colourFinished = new Dictionary<string, bool>(){
        {"Red", false},
        {"Blue", false},
        {"Yellow", false}};

    public bool isPuzzleSolved = false;

    private void Start()
    {
        timer = GameObject.FindObjectOfType<Timer>();
        timer.OnTimerDone += resetColour;
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

            // add puzzle solved sfx here
            timer.OnPuzzleDone();
        }
    }
}
