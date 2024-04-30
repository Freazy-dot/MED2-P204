using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    LightManager lightManager;

    private void Start()
    {
        lightManager = FindObjectOfType<LightManager>();

        if (lightManager == null) {
            Debug.LogError("LightManager not found in scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            LoadLevel();
        }
    }
    
    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            lightManager.SetLightIntensityPercentage(progress);

            yield return null;
        }
    }
}
