using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour
{
    public Toggle toggleFullScreen;
    
    private ColorAdjustments colorAdjustments;

    private void Start()
    {
        if (PlayerPrefs.HasKey("fullscreen"))
        {
            LoadSettings();
        }
        else
        {
            SetFullScreen(true);
        }
    }

    public void SetFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
        PlayerPrefs.SetInt("fullscreen", fullScreen ? 1 : 0);
    }

    private void LoadSettings()
    {
        SetFullScreen(PlayerPrefs.GetInt("fullscreen") != 0);
        toggleFullScreen.isOn = PlayerPrefs.GetInt("fullscreen") != 0;
    }
}
