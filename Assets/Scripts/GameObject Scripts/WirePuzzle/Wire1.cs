using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


//https://youtu.be/pKSUhsyrj_4?si=TK0DmCgr3koXpmD3


public class Wire1 : MonoBehaviour
{
    [SerializeField] GameObject wire, wireStart, wireEnd, lamp;
    SoundManager Soundman;

    void Start()
    {
        wireStart.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
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
            Soundman.playSFX("Cable_in");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!lamp.gameObject.GetComponent<MaterialSwitcher>()) return;
        lamp.gameObject.GetComponent<MaterialSwitcher>().RevertMaterialSwitch();
        Soundman.playSFX("Cable_out");
    }
}
