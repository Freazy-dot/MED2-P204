using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


//https://youtu.be/pKSUhsyrj_4?si=TK0DmCgr3koXpmD3


public class Wire1 : MonoBehaviour
{
    [SerializeField] GameObject wire, wireStart, wireEnd, lamp;
 
    //[SerializeField] Animator animator;
    //[SerializeField] WirePuzzle wirePuzzle;
   



    void Start()
    {
        wireStart.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
       
    }

    /// <summary>
    /// https://forum.unity.com/threads/how-to-change-a-single-material-at-an-object-which-has-multiple-materials.1261562/
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider collision)
    {

       if(collision.tag==this.tag)
        {
            //if (!lamp.gameObject.GetComponent<MaterialSwitcher>()) return;
            lamp.gameObject.GetComponent<MaterialSwitcher>().SwitchMaterial();


           // wirePuzzle.Add();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!lamp.gameObject.GetComponent<MaterialSwitcher>()) return;
        lamp.gameObject.GetComponent<MaterialSwitcher>().RevertMaterialSwitch();

       

       // wirePuzzle.Decrease();
    }
}