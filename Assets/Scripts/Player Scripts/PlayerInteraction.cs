using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour , IInteractable, IEquipable
{
    public void Interact(int objectType)
    {
        Debug.Log("Interacting with object of type " + objectType);
    }

    public void Equip()
    {
        Debug.Log("Equipping object");
    }

    public void Unequip()
    {
        Debug.Log("Unequipping object");
    }
}
