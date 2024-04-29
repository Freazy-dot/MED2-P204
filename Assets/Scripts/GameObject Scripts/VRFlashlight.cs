using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRFlashlight : MonoBehaviour, IPowerable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PowerOn()
    {
        Debug.Log("Flashlight On");
    }

    public void PowerOff()
    {
        Debug.Log("Flashlight Off");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
