using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _time = 0;
    public int timeLeft = 0;
    private Coroutine _countdown;

    public void StartTimer()
    {
        timeLeft = _time;
        _countdown = StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (timeLeft > 0)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
