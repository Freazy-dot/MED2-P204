using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    //Entire script is from: https://forum.unity.com/threads/how-to-change-a-single-material-at-an-object-which-has-multiple-materials.1261562/


    [SerializeField]
    int indexToSwitch = 1;

    [SerializeField]
    Material newMaterial, oldMaterial;


    private Material GetMeshMaterialAtIndex(int index)
    {
        return GetComponent<Renderer>().materials[index];
    }

    public void SwitchMaterial()
    {
        Material currentMaterial = GetMeshMaterialAtIndex(indexToSwitch);

        Debug.Log("Collison worked!");

        if (String.Equals(currentMaterial.name, newMaterial.name))
        {
            Debug.Log("Material already swapped!");
        }
        else
        {
            Material[] materials = GetComponent<Renderer>().materials;
            materials[indexToSwitch] = newMaterial;
            GetComponent<Renderer>().materials = materials;
            Debug.Log("Material swapped succesfully!");
        }
    }


    public void RevertMaterialSwitch()
    {
        Material currentMaterial = GetMeshMaterialAtIndex(indexToSwitch);

        Debug.Log("Collison worked!");

        if (String.Equals(currentMaterial.name, oldMaterial.name))
        {
            Debug.Log("Material already swapped!");
        }
        else
        {
            Material[] materials = GetComponent<Renderer>().materials;
            materials[indexToSwitch] = oldMaterial;
            GetComponent<Renderer>().materials = materials;
            Debug.Log("Material swapped succesfully!");
        }
    }
}
