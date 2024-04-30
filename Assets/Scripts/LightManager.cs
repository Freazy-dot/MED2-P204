using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light[] lights;
    public float[] lightIntensities;

    private void Start()
    {
        lights = FindObjectsOfType<Light>();
        lightIntensities = new float[lights.Length];
        for (int i = 0; i < lights.Length; i++) {
            lightIntensities[i] = lights[i].intensity;
        }
    }

    public void SetLightIntensityPercentage(float percentage)
    {
        for (int i = 0; i < lights.Length; i++) {
            lights[i].intensity = lights[i].intensity - (lightIntensities[i] * percentage);
        }
    }
}
