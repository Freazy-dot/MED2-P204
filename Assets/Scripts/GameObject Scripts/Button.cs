using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    SoundManager Soundman;
    ButtonManager buttonManager;
    string colour;
    string buttonId;

    private void Start()
    {
        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
        buttonManager = GameObject.FindObjectOfType<ButtonManager>();
        colour = this.gameObject.tag;
        buttonId = this.gameObject.name;
    }

    public void Interact(GameObject player)
    {
        Debug.Log("Button pressed");
        buttonManager.HandleButtonPress(player, colour, buttonId);
        Soundman.playSFX("Button_click");
    }
}