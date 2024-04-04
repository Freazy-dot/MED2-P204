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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

[Serializable]
public class CubeSpawnPoints
{
    public Transform spawnPoint;
    public GameObject[] cubePrefab;
    
}

