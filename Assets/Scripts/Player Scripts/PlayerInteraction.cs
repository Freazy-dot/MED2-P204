using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour , IInteractable
{
    PlayerInventory playerInventory;

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
                PlaceBattery();
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

    public void EquipBattery(GameObject gameObject) // equipping of battery needs implementation
    {
        playerInventory.AddBattery();
        Debug.Log("Equipping object");
        Destroy(gameObject);
    }

    public void UnequipBattery()
    {
        playerInventory.RemoveBattery();
        Debug.Log("Unequipping object");
    }

    public void PlaceBattery()
    {
        if (!playerInventory.HasBattery())
        {
            Debug.LogWarning("No Battery in inventory to place.");
            return;
        }
        Debug.Log("Placing object");
    }
}
