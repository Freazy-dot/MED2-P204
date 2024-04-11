using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IPowerable
{
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void PowerOn()
    {
        transform.Translate(Vector3.up * 2f); // Move the object upwards by 2 units
        Debug.Log("Opening Door");
    }

    public void PowerOff()
    {
        transform.position = originalPosition; // Return the object to its original position
        Debug.Log("Closing Door");
    }
}
  
