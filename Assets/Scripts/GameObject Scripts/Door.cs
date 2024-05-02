using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IPowerable
{
    private Vector3 originalPosition;
    SoundManager Soundman;

    private void Start()
    {
        originalPosition = transform.position;
        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
    }

    public void PowerOn()
    {
        Soundman.playSFX("Door_open");
        this.transform.Translate(Vector3.up * 4f); // Move the object upwards by 2 units
        Debug.Log("Opening Door");
                
    }

    public void PowerOff()
    {
        Soundman.playSFX("Door_closing");
        transform.position = originalPosition; // Return the object to its original position
        Debug.Log("Closing Door");
        
    }
}
  
