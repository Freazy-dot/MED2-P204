using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int batteryCount = 0;
    [SerializeField] private int inventorySize = 2;

    public bool HasBattery() {
        return batteryCount > 0;
    }
    public bool IsInventoryFull() {
        return batteryCount >= inventorySize;
    }
    public void AddBattery() {
        batteryCount++;
        Debug.Log("Battery added to inventory. Total: " + batteryCount);
    }
    public void RemoveBattery() {
        batteryCount--;
        Debug.Log("Battery removed from inventory. Total: " + batteryCount);
    }
}