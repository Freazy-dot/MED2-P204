using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class InstantiateCubes : MonoBehaviour
{
    public CubeSpawnPoints[] cubeSpawnPoints;
    
    // Start is called before the first frame update
    void Awake()
    {
        SpawnCube();
    }

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
    public Transform spawnPoint;
    public GameObject[] cubePrefab;
    [HideInInspector]public Cube cube;
    
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

    public void SpawnCube()
    {
        if (CanSpawnCube)
        {
            GameObject gb = Object.Instantiate(cubePrefab[Random.Range(0, cubePrefab.Length)], spawnPoint.position, Quaternion.identity);
            cube = gb.GetComponent<Cube>();
        }
    }

}

