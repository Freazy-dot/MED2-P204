using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UI;

public class Keypad2D : MonoBehaviour
{
    public delegate void CodeCorrectCallback();
    public event CodeCorrectCallback OnCodeCorrect;
    [SerializeField] private Text Ans;
    SoundManager Soundman;
    private string Code_Answer = "204659";

    private int Number_limit = 0;
    public Animator Panel;

    private void Awake()
    {
        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
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
            Panel.Play("remove_pad");
            OnCodeCorrect?.Invoke();
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


