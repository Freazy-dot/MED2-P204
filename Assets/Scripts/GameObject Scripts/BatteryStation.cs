using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryStation : MonoBehaviour, IInteractable
{
    public bool hasBattery = false;
    public GameObject linkedObject;

    public bool HasBattery()
    {
        return hasBattery;
    }

    public void Interact(GameObject player)
    {
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();

        if (hasBattery) {
            ReturnBattery(inventory);
            return;
        }
        
        if (!inventory.HasBattery()) {
            Debug.Log("No battery in inventory.");
            return;
        }
        
        if (linkedObject == null) {
            Debug.LogWarning("No linked object");
            return;
        }

        IPowerable powerable = linkedObject.GetComponent<IPowerable>();

        if (powerable == null) {
            Debug.LogWarning("No IPowerable interface found on linked object");
            return;
        }

        inventory.RemoveBattery();
        powerable.PowerOn();
        hasBattery = true;
    }

    public void ReturnBattery(PlayerInventory inventory)
    {
        if (inventory.batteryCount >= 2) {
            Debug.Log("Inventory is full.");
            return;
        }

        IPowerable powerable = linkedObject.GetComponent<IPowerable>();

        if (powerable == null) {
            Debug.LogWarning("No IPowerable interface found on linked object");
            return;
        }

        inventory.AddBattery();
        powerable.PowerOff();
        hasBattery = false;
    }
}
