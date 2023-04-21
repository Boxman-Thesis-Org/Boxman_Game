using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
 public AudioMixer audioMixer;
 public TMPro.TMP_Dropdown resolutionDropdown;

 Resolution[] resolutions;

 void Start () 
 {
   resolutions = Screen.resolutions;

   resolutionDropdown.ClearOptions();

   List<string> options = new List<string>();

   for (int i = 0; i < resolutions.Length; i++)
   {
     string option = resolutions[i].width + "x" + resolutions[i].height;
     options.Add(option);
   }

   resolutionDropdown.AddOptions(options);
 }

public void SetResolution (int resolutionIndex)
{
    Resolution resolution = resolutions[resolutionIndex];
    Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
}

public void SetVolume (float volume)
{
 audioMixer.SetFloat("volume", volume);
}

public void SetQuality (int qualityIndex)
{
    QualitySettings.SetQualityLevel(qualityIndex);
}

public void SetFullscreen (bool isFullscreen)
{
 Screen.fullScreen = isFullscreen;
}

}
