using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text Ans;
    SoundManager Soundman;

    private string Code_Answer = "1273";

    private int Number_limit = 0;

    public bool BatteryCheck;

    private void Start()
    {
        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
    }
    public void CheckForBattery()
    {
        if (BatteryCheck) // og e bliver trykket på!!!!!
        {
            //animation og keypad display kommer
            Debug.Log("YES BATTERY");
        }
        else
        {
            //animation eller en text siger der ikke er strøm til
            Debug.Log("NO BATTERY");
        }
    }

    public void Number(int number)
    {
        if (Number_limit < 4)
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
