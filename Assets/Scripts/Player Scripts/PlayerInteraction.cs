using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour , IInteractable
{
    PlayerInventory playerInventory;
    BatteryStation batteryStation;
    public void Start()
    {

        playerInventory = GetComponent<PlayerInventory>();

        if (playerInventory == null)
        {
            Debug.LogWarning("PlayerInventory component not found on PlayerInteraction script.");
        }
    }

    public void Interact(int objectType, GameObject gameObject)
    {
        switch (objectType)
        {
            case 0:
                Debug.Log("Interacting with object type 0 (Equip Battery)");
                EquipBattery(gameObject);
                break;
            case 1:
                Debug.Log("Interacting with object type 1 (Place Battery)");
                PlaceBattery(gameObject);
                break;
            case 2:
                Debug.Log("Interacting with object type 2 (Miscellaneous)");
                // Do something else with gameObject
                break;
            default:
                Debug.LogWarning("Interacting with object of invalid or missing type");
                break;
        }
    }

    public void EquipBattery(GameObject gameObject)
    {
        if (playerInventory.batteryCount >= 2)
        {
            Debug.LogWarning("Battery count is at maximum.");
            return;
        }
        playerInventory.AddBattery(gameObject);
        Destroy(gameObject);
        Debug.Log("Equipping object");
    }

    public void UnequipBattery()
    {
        playerInventory.RemoveBattery();
        Debug.Log("Unequipping object");
    }

    public void PlaceBattery(GameObject gameObject)
    {
        batteryStation = gameObject.GetComponent<BatteryStation>();
        if (batteryStation.HoldingBattery())
        {
            Debug.Log("Battery Station is already full");
            ReturnBattery();
            return;
        }
        if (!playerInventory.HasBattery())
        {
            Debug.LogWarning("No Battery in inventory to place.");
            return;
        }
        
       
        playerInventory.RemoveBattery();
        
        if (batteryStation != null)
        {
            batteryStation.InsertBattery();
        }
        else
        {
            Debug.LogWarning("BatteryStation component not found on object.");
        }
        Debug.Log("Placing object");
    }

    public void ReturnBattery()
    {
        if (playerInventory.batteryCount == 2)
        {
            Debug.LogWarning("Inventory full.");
            return;
        }

        playerInventory.AddBattery(gameObject);
        batteryStation.RemoveBattery();
        Debug.Log("Returning object");
    }
}
