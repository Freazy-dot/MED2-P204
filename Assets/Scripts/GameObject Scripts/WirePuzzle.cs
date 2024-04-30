using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class WirePuzzle : MonoBehaviour
{
    [SerializeField] int lightsOn;
    public Animator animator;
    [SerializeField] Wire1 wire1;
    [SerializeField] GameObject red, green, yellow, blue, purple, pink;


    private void Start()
    {
        wire1 = GetComponent<Wire1>();
        animator = GetComponent<Animator>();
        lightsOn = 0;
    }

    private void Update()
    {
        if (lightsOn >=6)
        {
            animator.SetTrigger("open");
        }
    }

    public void Add()
    {
        Debug.Log(lightsOn);
        lightsOn+=1;
        
    }

    public void Decrease()
    {
        Debug.Log(lightsOn);
        lightsOn-=1;
       
    }


}
