using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BatteryStation : MonoBehaviour, IInteractable
{
    public bool hasBattery = false;
    public GameObject linkedObject;

    // testing purpose things:
    public Material material;
    private Material originalMaterial;
    private Renderer objectRenderer;
    SoundManager Soundman;

    public void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalMaterial = objectRenderer.material;
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
        Soundman.playSFX("Battery_slot_sfx");

        objectRenderer.material = material; // testing purpose
    }

    public void ReturnBattery(PlayerInventory inventory, IPowerable powerable)
    {    
        // check if the player's inventory is full
        if (inventory.IsInventoryFull()) {
            Debug.Log("Inventory is Full.");
            return;
        }

        inventory.AddBattery();
        powerable.PowerOff();
        hasBattery = false;

        objectRenderer.material = originalMaterial; // testing purpose
    }
}
