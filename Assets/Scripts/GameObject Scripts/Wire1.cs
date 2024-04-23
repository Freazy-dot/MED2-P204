using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


//https://youtu.be/pKSUhsyrj_4?si=TK0DmCgr3koXpmD3


public class Wire1 : MonoBehaviour
{
    [SerializeField] GameObject wireStart, wireEnd, socketCollider, lamp;

    [SerializeField] Material colourLightOn;
    Material colourLightOff;

    [SerializeField] MeshRenderer lampMeshRenderer;






    void Start()
    {
        wireStart.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        lampMeshRenderer = lamp.GetComponent<MeshRenderer>();
        colourLightOff = lampMeshRenderer.material;
        colourLightOn.mainTextureScale = colourLightOff.mainTextureScale;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) { ChangeMaterial(); }
    }


    public void ChangeMaterial()
    {
        lampMeshRenderer.material = lampMeshRenderer.material.name.StartsWith(colourLightOn.name) ? colourLightOff : colourLightOn;
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
     //   lamp.GetComponent<MeshRenderer>().material = colourLight;
    }


}
