using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;


//https://youtu.be/pKSUhsyrj_4?si=TK0DmCgr3koXpmD3


public class Wire2 : MonoBehaviour
{
    [SerializeField] GameObject lamp;

     public Material colourLightOn;
    Material colourLightOff;

    MeshRenderer lampMeshRenderer;






    void Start()
    {
       
       // lamp.gameObject.GetComponent<Renderer>().material = colourLightOn;
        lampMeshRenderer = lamp.GetComponent<MeshRenderer>();
        colourLightOff = lampMeshRenderer.material;
        colourLightOn.mainTextureScale = colourLightOff.mainTextureScale;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) { lamp.gameObject.GetComponent<Renderer>().material = colourLightOn; }
    }


    public void ChangeMaterial()
    {
        lampMeshRenderer.material = lampMeshRenderer.material.name.StartsWith(colourLightOn.name) ? colourLightOff : colourLightOn;
    }


    private void OnCollisionEnter(Collision collision)
    {
     
        lamp.gameObject.GetComponent<Renderer>().material = colourLightOn;
    }


}
