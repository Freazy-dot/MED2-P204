using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour, IInteractable
{
    public Color buttonColor;
    public ButtonManager buttonManager;
    public LevelLoader levelLoader;

    public void Interact(GameObject player)
    {
        if (this.gameObject.tag == "EndButton") {
            levelLoader = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
            levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        Debug.Log("Button pressed: " + buttonColor);
        buttonManager.HandleButtonPress(buttonColor, player);
    }
}