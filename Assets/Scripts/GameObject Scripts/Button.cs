using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    SoundManager Soundman;
    public Color buttonColor;
    public ButtonManager buttonManager;

    private void Start()
    {
        //Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
    }

    public void Interact(GameObject player)
    {
        Debug.Log("Button pressed: " + buttonColor);
        buttonManager.HandleButtonPress(buttonColor, player);
        //Soundman.playSFX("Button_click");
    }
}