using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuB : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider fullScreen;

    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    public Slider quality;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add (option);
        }

        resolutionDropdown.AddOptions (options);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen
            .SetResolution(resolution.width,
            resolution.height,
            Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void FullScreen()
    {
        if (fullScreen.value == 1)
        {
            Screen.fullScreen = true;
            Debug.Log("FullScreen");
        }
        else
        {
            Screen.fullScreen = false;
            Debug.Log("FullScreen is False");
        }
    }

    public void Quality(int qualityIndex)
    {
        //Setting the variable qualityIndex equal to the value of the quality slider bar
        //Slider bar values are automatically floats so converting that to an int
        qualityIndex = (int) quality.value;

        //Debug.Log(qualityIndex);
        //The quality index values are in reverse order
        //So the slider value will set the quality index to the opposite value on the scale
        //Hence the if statements
        if (quality.value == 0)
        {
            QualitySettings.SetQualityLevel(2);
        }
        else if (quality.value == 1)
        {
            QualitySettings.SetQualityLevel(1);
        }
        else if (quality.value == 2)
        {
            QualitySettings.SetQualityLevel(0);
        }
    }
}
