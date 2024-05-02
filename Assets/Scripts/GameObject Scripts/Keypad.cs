using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour, IPowerable, IInteractable
{

    public Animator Panel;
    public Keypad2D keypad2D;
    public GameObject linkedObject;
   

    public bool keypadIsActive = false;

    public bool Showkeypad;



    private void Start()
    {
        keypad2D.OnCodeCorrect += CodeCorrectHandler;
        
    }
    private void CodeCorrectHandler()
    {
       PowerLinkedObject();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Panel.Play("remove_pad");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void PowerOn()
    {
        keypadIsActive = true;

    }
    public void PowerOff() 
    { 
        keypadIsActive = false;
    }

    public void Interact(GameObject Player)
    { 
        if (keypadIsActive) 
        {
            //Keypad on camera
            Debug.Log("Keypad is Active");
            Panel.Play("Show_NumPad");
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            

        }
        else if (!keypadIsActive)
        {
            Debug.LogWarning("Keypad Not Active");
            
        }
    }

    public void PowerLinkedObject()
    {
        if (linkedObject == null)
        {
            Debug.LogWarning("No linked object");
            return;
        }

        IPowerable powerable = linkedObject.GetComponent<IPowerable>();
        if (powerable == null)
        {
            Debug.LogWarning("No IPowerable interface found on linked object");
            return;
        }

        powerable.PowerOn();
    }

}
