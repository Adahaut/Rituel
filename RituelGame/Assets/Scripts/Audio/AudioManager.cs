using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup = s.audioMixerGroup;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (!s.source.isPlaying)
        {
            s.source.Play();
        }
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void stopAllSounds()
    {
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying)
            {
                s.source.Stop();
            }
        }
    }

    public void ChangePitch(string name, float pitch)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.pitch = pitch;
    }

    //placer dans nimporte quel scrypt avec le bon nom dans les "" pour jouer un son
    //FindObjectOfType<AudioManager>().X("");
    //X is the name of the function called
}
