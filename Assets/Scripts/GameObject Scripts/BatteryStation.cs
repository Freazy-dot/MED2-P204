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
    public void InsertBattery()
    {
        holdingBattery = true;
        PerformAction();
    }

    public void PerformAction()
    {
        if (linkedObject != null)
        {
         IPowerable powerable = linkedObject.GetComponent<IPowerable>();

            if (powerable != null)
            {
                powerable.InteractWithBatteryStation();
            }
            else
            {
                Debug.LogWarning("No IPowerable interface found on linked object");
            }
        }
        
        else
        {
            Debug.LogWarning("No linked object");
        }
    }

    public void RemoveBattery()
    {
        holdingBattery = false;
        //playerInteraction.EquipBattery(gameObject);
    }
}
