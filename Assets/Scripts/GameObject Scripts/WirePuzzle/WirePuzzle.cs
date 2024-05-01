using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.Controls.AxisControl;

public class WirePuzzle : MonoBehaviour
{
    
    Animator animator;

    
  [SerializeField] MaterialSwitcher mRed, mGreen, mYellow, mBlue, mPurple, mPink;

    private void Start()
    {
      
       animator = GetComponent<Animator>();
        
    }

    private void Update()
    {

        if (mRed.isOn == true && mGreen.isOn == true && mYellow.isOn == true && mBlue.isOn == true && mPurple.isOn == true && mPink.isOn == true)
        {
            animator.SetTrigger("open");

        }
    }

  


}
