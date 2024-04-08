using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int batteryCount = 0;

    public bool HasBattery() {
        return batteryCount > 0;
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