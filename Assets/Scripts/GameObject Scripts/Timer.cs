using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _time = 0;
    public int timeLeft = 0;
    private Coroutine _countdown;
    public Text timerText;
    public ButtonManager buttonManager; // Add this line

    public void StartTimer()
    {
        timeLeft = _time;
        _countdown = StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            timerText.text = "Time left: " + timeLeft;
            Debug.Log("Time left: " + timeLeft);
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        timerText.text = "Time's up!";
        buttonManager.ResetButtonCounts(); // Call the ResetButtonCounts method in the ButtonManager
    }
}