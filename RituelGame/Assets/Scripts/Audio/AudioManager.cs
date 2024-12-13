using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private float timeBetweenMusics;

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
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    private void Start()
    {
        PlaySound("Music");
    }

    private void Update()
    {
        timeBetweenMusics += Time.deltaTime;
        if (timeBetweenMusics >= GetLength("Music"))
        {
            PlaySound("Music");
        }
    }

    public void PlaySound (string name)//pas utilisé
    {
        try
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }
        catch
        {
            Debug.LogWarning(name + " sound not found");
        }
    }

    public void PlayOverlap(string name)
    {
        try
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.PlayOneShot(s.source.clip, s.source.volume);
        }
        catch
        {
            Debug.LogWarning(name + " sound not found");
        }
    }

    public void PlayDelay(string name,float delay)
    {
        StartCoroutine(PlayDelayCoroutine(delay, name));
    }

    private IEnumerator PlayDelayCoroutine(float delay, string name)
    {
        yield return new WaitForSeconds(delay);
        PlayOverlap(name);
    }

    public void StopSound(string name)//pas utilisé
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void stopAllSounds()// pas utilisé
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
    
    public void ChangeVolume(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = volume;
    }

    public float GetLength(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s.source.clip.length;
    }

    public void FadeOut(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        for (float i = 0; s.source.volume <= 0; i++)
        {
            s.source.volume -= Time.deltaTime / 2;
        }
    }

    //placer dans nimporte quel scrypt avec le bon nom dans les "" pour jouer un son
    //FindObjectOfType<AudioManager>().X("");
    //X is the name of the function called
}
