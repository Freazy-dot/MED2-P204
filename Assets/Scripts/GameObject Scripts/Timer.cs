using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private readonly int _timer = 20;
    public int timer;
    private IEnumerator _countdown;

    [SerializeField] private TextMeshPro _timerText;

    private void Start()
    {
        _timerText = GetComponent<TextMeshPro>();
    }
    
    public void StartTimer()
    {
        timer = _timer;
        _countdown = Countdown();
        StartCoroutine(_countdown);
    }

    public void StopTimer() 
    {
        StopCoroutine(_countdown);

        _timerText.text = " ";
    }

    public void ResetTimer()
    {
        if (timer > 0) {
            StopTimer();
        }

        StartTimer();
    }

    private IEnumerator Countdown()
    {
        while (timer > 0) {
            _timerText.text = timer.ToString();
            Debug.Log(timer);
            yield return new WaitForSeconds(1);
            timer--;
        }
        onTimerDone();
    }

    public Action OnTimerDone;
    private void onTimerDone()
    {
        _timerText.text = " ";
        OnTimerDone?.Invoke();
    }

    public void OnPuzzleDone()
    {
        StopTimer();

        _timerText.text = "finished puzzle well done idiot";
    }
}