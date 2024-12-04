using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour
{
    public Slider brightnessSlider;
    public Toggle toggleFullScreen;
    
    public Volume postProcessingVolume;
    private ColorAdjustments colorAdjustments;

    private void Start()
    {
        postProcessingVolume.profile.TryGet(out colorAdjustments);

        if (PlayerPrefs.HasKey("fullscreen") && PlayerPrefs.HasKey("brightness"))
        {
            LoadSettings();
        }
        else
        {
            SetBrightness(0);
            SetFullScreen(true);
        }
    }
    
    public void SetBrightness(float brightness)
    {
        colorAdjustments.postExposure.overrideState = true;
        colorAdjustments.postExposure.value = brightness;
        PlayerPrefs.SetFloat("brightness", brightness);
    }

    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
        PlayerPrefs.SetInt("fullscreen", fullScreen ? 1 : 0);
    }

    private void LoadSettings()
    {
        SetBrightness(PlayerPrefs.GetFloat("brightness"));
        brightnessSlider.value = PlayerPrefs.GetFloat("brightness");

        SetFullScreen(PlayerPrefs.GetInt("fullscreen") != 0);
        toggleFullScreen.isOn = PlayerPrefs.GetInt("fullscreen") != 0;
    }
}
