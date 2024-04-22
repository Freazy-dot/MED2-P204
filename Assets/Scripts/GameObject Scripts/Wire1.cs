using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


//https://youtu.be/pKSUhsyrj_4?si=TK0DmCgr3koXpmD3


public class Wire1 : MonoBehaviour
{
    [SerializeField] GameObject wireStart;








    void Start()
    {
        wireStart.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    void Update()
    { }


  

}
