using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


//https://youtu.be/pKSUhsyrj_4?si=TK0DmCgr3koXpmD3


public class Wire1 : MonoBehaviour
{
    [SerializeField] GameObject wire, wireStart, wireEnd, lamp;

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

        Debug.Log("Collision");

       if(collision.tag==this.tag)
        {
            //if (!lamp.gameObject.GetComponent<MaterialSwitcher>()) return;
            lamp.gameObject.GetComponent<MaterialSwitcher>().SwitchMaterial();
        }
    }

   private void OnTriggerExit(Collider collision)
    {
        Debug.Log("collision exit");

        if (!lamp.gameObject.GetComponent<MaterialSwitcher>()) return;
        if (collision.tag == this.tag)
        {
            lamp.gameObject.GetComponent<MaterialSwitcher>().RevertMaterialSwitch();
        }
        else return;
    }
}
