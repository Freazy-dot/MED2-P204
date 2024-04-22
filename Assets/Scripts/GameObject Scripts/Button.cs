using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    public Color buttonColor;
    public ButtonManager buttonManager;

    public void Interact(GameObject player)
    {
        Debug.Log("Button pressed: " + buttonColor);
        buttonManager.HandleButtonPress(buttonColor, player);
    }
}