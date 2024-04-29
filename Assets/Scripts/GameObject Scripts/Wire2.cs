using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


public class Wire2 : MonoBehaviour
{
    [SerializeField] GameObject boxFront, boxBottom, boxRight, boxLeft, boxTop;
    [SerializeField] GameObject wireRed, wireGreen, wireBlue, wireYellow, wirePurple, wirePink;
    [SerializeField] Material material;

        void Start()
    {
        
                boxFront.GetComponent<Rigidbody>().useGravity = false;
                boxBottom.GetComponent<Rigidbody>().useGravity = false;
    }

  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
           boxFront.GetComponent<Rigidbody>().useGravity = true;
           boxBottom.GetComponent<Rigidbody>().useGravity = true;

           // boxFront.SetActive (false);
           // boxBottom.SetActive (false);

            wireRed.SetActive(true);
            wireGreen.SetActive(true);
            wireBlue.SetActive(true);
            wireYellow.SetActive(true);
            wirePurple.SetActive(true);
            wirePink.SetActive(true);

            boxRight.GetComponent<Renderer>().material = material;
            boxLeft.GetComponent<Renderer>().material = material;
            boxTop.GetComponent<Renderer>().material = material;
        }
    }

    public void ActivateWires()
    {

    }


}
