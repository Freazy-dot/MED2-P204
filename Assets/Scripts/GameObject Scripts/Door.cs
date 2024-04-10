using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IPowerable
{
    public void InteractWithBatteryStation()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        Debug.Log("Opening Door");
    }
}
  
