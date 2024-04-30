using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    LightManager lightManager;
    public GameObject loadingScreen;
    public Slider slider;
    
    private void Start()
    {
        lightManager = FindObjectOfType<LightManager>();

        if (lightManager == null) {
            Debug.LogError("LightManager not found in scene.");
        }
    }
    
    public void LoadLevel()
    {
        lightManager.StartCoroutine(lightManager.DimLights(() => StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1))));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }
}
