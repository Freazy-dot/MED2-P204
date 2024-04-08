using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int batteryCount = 0;

    public bool HasBattery() {
        return batteryCount > 0;
    }
    public void AddBattery(GameObject gameObject) {
        if (batteryCount >= 2) {
            Debug.LogWarning("Battery count is at maximum.");
            return;
        }
        batteryCount++;
        Destroy(gameObject);
        Debug.Log("Battery added to inventory. Total: " + batteryCount);
    }
    public void RemoveBattery() {
        batteryCount--;
        Debug.Log("Battery removed from inventory. Total: " + batteryCount);
        if (batteryCount < 0) {
            Debug.LogWarning("Battery count is negative.");
        }
    }
}