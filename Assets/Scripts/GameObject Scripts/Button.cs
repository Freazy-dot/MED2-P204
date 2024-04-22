using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
private Timer timer;

    public void Start()
    {
        timer = GetComponent<Timer>();
    }

    public void Interact(GameObject player)
    {
        if (timer.timeLeft > 0) {
            
        }

        timer.StartTimer();
    }
}
