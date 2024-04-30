using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light[] lights;
    public float[] lightIntensities;
    public float brightenDuration = 5f;
    public float dimDuration = 0.01f;

    private void Awake()
    {
        lights = FindObjectsOfType<Light>();
        lightIntensities = new float[lights.Length];
        for (int i = 0; i < lights.Length; i++) {
            lightIntensities[i] = lights[i].intensity;
        }
    }
    
    private void Start()
    {
        for (int i = 0; i < lights.Length; i++) {
            lights[i].intensity = 0;
        }

        StartCoroutine(BrightenLights());
    }

    private IEnumerator BrightenLights()
    {
        float startTime = Time.time;

        while (Time.time - startTime <= brightenDuration) {
            float t = (Time.time - startTime) / brightenDuration;

            for (int i = 0; i < lights.Length; i++) {
                lights[i].intensity = Mathf.Lerp(0, lightIntensities[i], t);
            }
            
            yield return null;
        }
    }

    public IEnumerator DimLights(System.Action callback)
    {
        float startTime = Time.time;

        while (Time.time - startTime <= dimDuration) {
            float t = (Time.time - startTime) / dimDuration;

            for (int i = 0; i < lights.Length; i++) {
                lights[i].intensity = Mathf.Lerp(lightIntensities[i], 0, t);
            }

            yield return null;
        }

        callback?.Invoke();
    }
}
