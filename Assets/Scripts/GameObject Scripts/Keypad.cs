using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour, IPowerable, IInteractable
{
    [SerializeField] private Text Ans;
    SoundManager Soundman;

    private string Code_Answer = "204659";

    private int Number_limit = 0;

    public bool keypadIsActive = false;

    private void Start()
    {
        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
        
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
        }
        else if (!keypadIsActive)
        {
            Debug.LogWarning("Keypad Not Active");
        }
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
            Ans.text = "GET IN HERE BOI";
            Number_limit = 0;
            Soundman.playSFX("KeyCode_right");
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
