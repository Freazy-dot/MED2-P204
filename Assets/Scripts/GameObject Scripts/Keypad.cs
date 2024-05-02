using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour, IPowerable, IInteractable
{
    [SerializeField] private Text Ans;
    SoundManager Soundman;

    public Animator Panel;

    public GameObject linkedObject;
   

    private string Code_Answer = "204659";

    private int Number_limit = 0;

    public bool keypadIsActive = false;

    public bool Showkeypad;

    private void Start()
    {
        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
        
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
        IPowerable powerable = linkedObject.GetComponent<IPowerable>(); 
        if (linkedObject == null)
        {
            Debug.LogWarning("No linked object");
            return;
        }
        if (powerable == null)
        {
            Debug.LogWarning("No IPowerable interface found on linked object");
            return;
        }

        powerable.PowerOn();

    }
    public void Number(int number)
    {
        if (Number_limit < 6)
        {
            Ans.text += number.ToString();
            Number_limit = Number_limit + 1;
        }

    }
  
    public void Clear_Num()
    {
        Ans.text = null;
        Number_limit = 0;
    }

    public void TryCode()
    {
        if (Ans.text == Code_Answer)
        {
            //Do thingy her
            Ans.text = "CORRECT";
            Number_limit = 0;
            Soundman.playSFX("KeyCode_right");
            StartCoroutine(Delay());
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PowerLinkedObject();
            Panel.Play("remove_pad");
        }
        else
        {
            Ans.text = "INCORRECT";
            StartCoroutine(Delay());
            Soundman.playSFX("KeyCode_wrong");
        }
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        Ans.text = null;
        Number_limit = 0;
    }
}
