using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryStation : MonoBehaviour
{
    public bool holdingBattery = false;
    public GameObject linkedObject;
    //PlayerInteraction playerInteraction;

    private void Awake()
    {
        //playerInteraction = FindObjectOfType<PlayerInteraction>();

    }

    public bool HoldingBattery()
    {
        return holdingBattery;
    }

    public void PerformAction()
    {
        if (linkedObject != null)
        {
            if (linkedObject.CompareTag("Door"))
            {
                linkedObject.GetComponent<Door>().OpenDoor();
            }
            else if (linkedObject.CompareTag("Cube"))
            {
                linkedObject.GetComponent<Cube>().MoveCube();
            }
        }
        
        else
        {
            Debug.Log("No linked object");
        }
    }

    public void InsertBattery()
    {
        holdingBattery = true;
        //playerInteraction.UnequipBattery();
        PerformAction();
    }

    public void RemoveBattery()
    {
        holdingBattery = false;
        //playerInteraction.EquipBattery(gameObject);
    }
}
