using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int time = 75;
    private int _timer;
    private IEnumerator _countdown;

    private TextMeshPro _timerText;

    SoundManager Soundman;

    private void Start()
    {
        _timerText = GetComponent<TextMeshPro>();
        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
    }

    public void StartTimer()
    {
        _timer = time;
        _countdown = Countdown();
        StartCoroutine(_countdown);
        Soundman.playSFX("Time_tick");
    }

    public void StopTimer() 
    {
        StopCoroutine(_countdown);

        _timerText.text = " ";
        
        Soundman.BreakSounds();
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
        Soundman.BreakSounds();
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

        _timerText.text = "0.0";
    }
}