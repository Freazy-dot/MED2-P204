using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRFlashlight : MonoBehaviour, IInteractable, IPowerable

{
    public bool hasBattery = false;
    public Light flashlight;
    // Start is called before the first frame update
    void Start()
    {


    }

    public void Interact(GameObject player)
    {
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        IPowerable powerable = GetComponent<IPowerable>();


        if (powerable == null)
        {
            Debug.LogWarning("No IPowerable interface found");
            return;
        }
        if (hasBattery)
        {
            ReturnBattery(inventory, powerable);
            hasBattery = false;
            return;
        }

        if (!inventory.HasBattery())
        {
            Debug.Log("Inventory is Empty.");
            return;
        }
        
       

        inventory.RemoveBattery();
        powerable.PowerOn();
        hasBattery = true;

    }
    public void PowerOn()
    {
       flashlight.enabled = true;
        Debug.Log("Flashlight On");
    }

    public void PowerOff()
    {
        flashlight.enabled = false;
        Debug.Log("Flashlight Off");
    }
    public void ReturnBattery(PlayerInventory inventory, IPowerable powerable)
    {
        // check if the player's inventory is full
        if (inventory.IsInventoryFull())
        {
            Debug.Log("Inventory is Full.");
            return;
        }

        inventory.AddBattery();
        powerable.PowerOff();
        hasBattery = false;

    }
}
