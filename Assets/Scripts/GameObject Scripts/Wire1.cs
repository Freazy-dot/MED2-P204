using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


//https://youtu.be/pKSUhsyrj_4?si=TK0DmCgr3koXpmD3


public class Wire1 : MonoBehaviour
{
    [SerializeField] GameObject wireStart, wireEnd, socketCollider, lamp;

    [SerializeField] Material colourLightOn;

   

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
        if (!lamp.gameObject.GetComponent<MaterialSwitcher>()) return;
        lamp.gameObject.GetComponent<MaterialSwitcher>().SwitchMaterial();
    }

 /*   public void OnTriggerEnter(Collider collision)
    {
        lamp.GetComponent<MeshRenderer>().material = colourLightOn;
    }*/
}
