using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelLoaderTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
            levelLoader.LoadLevel();
        }
    }
}