using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Add this line

public class Timer : MonoBehaviour
{
    [SerializeField] private int _time = 0;
    public int timeLeft = 0;
    private Coroutine _countdown;
    public Text timerText; // Add this line

    public void StartTimer()
    {
        timeLeft = _time;
        _countdown = StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            timerText.text = "Time left: " + timeLeft; // Add this line
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
        timerText.text = "Time's up!"; // Add this line
    }
}