using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            //tu peux créer une fonction dans Sound pour ça
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    public void PlaySound (string name) //pas utiliser
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void PlayOneShot(string name)//mauvais nom de fonction
    {
        //chaque fois que tu veux jouer un son tu rechercher parmis toute ta list, pas fou comme system
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.PlayOneShot(s.source.clip, s.source.volume);
    }

    public void StopSound(string name)//pas utiliser
    {
        //tu refais la même chose ici 
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void stopAllSounds()// pas utiliser
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
        //et encore ici
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.pitch = pitch;
    }

    //placer dans nimporte quel scrypt avec le bon nom dans les "" pour jouer un son
    //FindObjectOfType<AudioManager>().X("");
    //X is the name of the function called
}
