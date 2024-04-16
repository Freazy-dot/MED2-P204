using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
   public AudioMixer audiomixer;

   public Dropdown resolutionDropdown;
    
   Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        // clear out the options from the reolution dropdown
        resolutionDropdown.ClearOptions();

        // List of strings which is the options
        List<string> options = new List<string>();

        int curretnResolutionindex = 0;

        //loop through each element in the array, where it creataes a string that displays the resolution in th eoptions list
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                curretnResolutionindex = i;
            }
        }

        //adds option list to the resolution dropdown
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = curretnResolutionindex;
        resolutionDropdown.RefreshShownValue();

    }

    public void Setresolution (int resolutionindex)
    {
        Resolution resolution = resolutions[resolutionindex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);   
    }
    public void VolumeSlide (float volume)
    {
        audiomixer.SetFloat("Volume_Mix", volume);
    }

    public void Quality (int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }

    public void Fullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
