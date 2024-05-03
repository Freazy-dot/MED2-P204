using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int time = 20;
    private int _timer;
    private IEnumerator _countdown;

    private TextMeshPro _timerText;

    private void Start()
    {
        _timerText = GetComponent<TextMeshPro>();
    }

    public void StartTimer()
    {
        _timer = time;
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
        if (_timer > 0) {
            StopTimer();
        }

        StartTimer();
    }

    private IEnumerator Countdown()
    {
        while (_timer > 0) {
            _timerText.text = _timer.ToString();
            Debug.Log(_timer);
            yield return new WaitForSeconds(1);
            _timer--;
        }
        OnTimerDone();
    }

    public Action onTimerDone;
    private void OnTimerDone()
    {
        _timerText.text = " ";
        onTimerDone?.Invoke();
    }

    public void OnPuzzleDone()
    {
        StopTimer();

        _timerText.text = "finished puzzle well done idiot";
    }
}