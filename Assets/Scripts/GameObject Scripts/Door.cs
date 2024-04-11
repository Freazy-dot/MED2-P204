using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IPowerable
{
    public void PowerOn()
    {
        Debug.Log("Opening Door");
    }

    public void PowerOff()
    {
        Debug.Log("Closing Door");
    }
}
  
