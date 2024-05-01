using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int batteryCount = 0;
    [SerializeField] private int inventorySize = 2;
    // [SerializeField] private List<GameObject> batteryVisuals;
    SoundManager Soundman;

    private void Start()
    {
        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
    }
    public bool HasBattery() {
        return batteryCount > 0;
    }
    public bool IsInventoryFull() {
        return batteryCount >= inventorySize;
    }
    public void AddBattery() {
        batteryCount++;
        Debug.Log("Battery added to inventory. Total: " + batteryCount);
        Soundman.playSFX("Pickup_battery");
        UpdateBatteryVisuals();
    }
    public void RemoveBattery() {
        batteryCount--;
        Debug.Log("Battery removed from inventory. Total: " + batteryCount);

        UpdateBatteryVisuals();
    }

    public void UpdateBatteryVisuals() 
    {
        return;
    }
}