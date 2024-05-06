using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BatteryStation : MonoBehaviour, IInteractable
{
    public bool hasBattery = false;
    public GameObject linkedObject;
    public int batteryCount = 0;
    [SerializeField]private List<GameObject> batteryVisuals;

    // testing purpose things:
   
    SoundManager Soundman;

    public void Start()
    {
      Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
     
    }
    // rest of tesing thing at the end of Interact() and ReturnBattery()

    public bool HasBattery()
    {
        return hasBattery;
    }

    public void Interact(GameObject player)
    {
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        IPowerable powerable = linkedObject.GetComponent<IPowerable>();

        // check if the battery station has a linked object
        if (linkedObject == null) {
            Debug.LogWarning("No linked object");
            return;
        }

        // check if the linked object has the IPowerable interface
        if (powerable == null) {
            Debug.LogWarning("No IPowerable interface found on linked object");
            return;
        }
        
        // check if the battery station already has a battery
        if (hasBattery) {
            ReturnBattery(inventory, powerable);
            UpdateBatteryVisuals();
            return;
        }
        
        // check if the player has a battery
        if (!inventory.HasBattery()) {
            Debug.Log("Inventory is Empty.");
            return;
        }

        inventory.RemoveBattery();
        powerable.PowerOn();
        hasBattery = true;
        batteryCount++;
        UpdateBatteryVisuals();
        Soundman.playSFX("Battery_slot_sfx");

    }

    public void ReturnBattery(PlayerInventory inventory, IPowerable powerable)
    {    
        // check if the player's inventory is full
        if (inventory.IsInventoryFull()) {
            Debug.Log("Inventory is Full.");
            return;
        }
        
        batteryCount--;
        inventory.AddBattery();
        powerable.PowerOff();
        hasBattery = false;

     }
    public void UpdateBatteryVisuals()
    {
        for (int i = 0; i < batteryVisuals.Count; i++)
        {
            batteryVisuals[i].SetActive(i < batteryCount);
        }
    }   
}
