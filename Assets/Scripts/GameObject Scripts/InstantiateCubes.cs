using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
using UnityEngine.XR.Interaction.Toolkit;

public class InstantiateCubes : MonoBehaviour
{
    public CubeSpawnPoints[] cubeSpawnPoints; //Array of CubeSpawnPoints, which is set in the inspector


    // Awake is called when the script instance is being loaded
    //Calls the SpawnCube method
    void Awake()
    {
        XRBaseInteractor interactor = GetComponent<XRBaseInteractor>();


    }

    public void OnHoverEntered()
    {
        SpawnCube();
    }

    //Spawns the cube for each spawn point


    private void SpawnCube()
    {
        foreach (CubeSpawnPoints cubeSpawnPoint in cubeSpawnPoints)
        {
            cubeSpawnPoint.SpawnCube();
        }
    }

}

[Serializable]
public class CubeSpawnPoints
{
    public Transform spawnPoint; //The spawn point of the cube
    public GameObject[] cubePrefab; //Array of cube prefabs
    [HideInInspector]public Cube cube;
    //check if the cube can be spawned
    public bool CanSpawnCube
    {
        get
        {
            foreach (PlayerLocomotion obj in GameObject.FindObjectsOfType(typeof(PlayerLocomotion)))
            {
                if (Vector3.Distance(obj.transform.position, spawnPoint.position) < 1.5f)
                {
                    return false;
                }
            }

            if (cube)
            {
                return false;
            }

            return true;
        }
    }
    //Spawn the cube
    public void SpawnCube()
    {
        if (CanSpawnCube)
        {
            GameObject gb = Object.Instantiate(cubePrefab[Random.Range(0, cubePrefab.Length)], spawnPoint.position, Quaternion.identity);
            cube = gb.GetComponent<Cube>();
        }
    }

}

