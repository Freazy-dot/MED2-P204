using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battery : MonoBehaviour, IInteractable
{
    [SerializeField]Animator animator;
    public void Interact(GameObject player)
    {
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        if (inventory.IsInventoryFull())
        {
            Debug.LogWarning("Inventory is Full.");
            return;
        }
        if (SceneManager.GetActiveScene().name == "Level-3")
        {
            animator.SetTrigger("Open");
            Debug.Log("Battery removed");
        }
       
        
        inventory.AddBattery();
        Destroy(this.gameObject);
    }
}
