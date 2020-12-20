using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    private Slider volumeSlider;
    Resolution[] resolutions;
    float currentVolume;
    private void Start()
    {
        volumeSlider = GameObject.Find("Volume").GetComponent<Slider>();
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("ResolutionPreference",resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference",Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference", currentVolume);
        
    }
    public void SetVolume()
    {
        this.currentVolume = volumeSlider.value;
        AudioListener.volume = currentVolume;
    }
    public void SetFullscreen()
    {
        Screen.fullScreen = GameObject.Find("Toggle").GetComponent<Toggle>().isOn;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIndex;
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
        if (PlayerPrefs.HasKey("VolumePreference"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
            AudioListener.volume = PlayerPrefs.GetFloat("VolumePreference");
        }
        else
            volumeSlider.value = 1;
    }
    public void CloseSettings(bool save)
    {
        if (save)
        {
            SaveSettings();
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
