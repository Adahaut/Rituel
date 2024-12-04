using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider voiceSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") && PlayerPrefs.HasKey("sfxVolume") && PlayerPrefs.HasKey("voiceVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume(musicSlider.value);
            SetSFXVolume(sfxSlider.value);
            SetVoiceVolume(voiceSlider.value);
        }
    }

    public void SetMusicVolume(float volume)
    {
        mixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    
    public void SetSFXVolume(float volume)
    {
        mixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
    
    public void SetVoiceVolume(float volume)
    {
        mixer.SetFloat("VoiceVolume", volume);
        PlayerPrefs.SetFloat("voiceVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume(musicSlider.value);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetSFXVolume(sfxSlider.value);
        voiceSlider.value = PlayerPrefs.GetFloat("voiceVolume");
        SetVoiceVolume(voiceSlider.value);
    }
}
