using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text Ans;

    private string Code_Answer = "1273";

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Clear_Num()
    {
        Ans.text = null; 
    }
    public void TryCode()
    {
        if (Ans.text == Code_Answer)
        {
            //Do thingy her
            Ans.text = "GET IN HERE BOI";
        }
        else
        {
            Ans.text = "INCORRECT";
            StartCoroutine(Delay());
            
        }
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        Ans.text = null;
    }
}
