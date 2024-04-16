using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Battery : MonoBehaviour, IInteractable
{
    public void Interact(GameObject player)
    {
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        if (inventory.IsInventoryFull()) {
            Debug.LogWarning("Inventory is Full.");
            return;
        }
        inventory.AddBattery();
        Destroy(this.gameObject);
    }
}
