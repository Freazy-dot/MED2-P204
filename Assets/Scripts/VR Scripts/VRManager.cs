using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRManager : MonoBehaviour
{
    // Start is called before the first frame update
    //Disables the device view for vr, so we can test without building
    void Start()
    {
        UnityEngine.XR.XRSettings.showDeviceView = false;
    }
}
