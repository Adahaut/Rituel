using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range (.1f, 3f)]
    public float pitch;
    public bool loop;
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
    
    //creer des fonctions a utiliser ici comme Init() par exemple pour faire ce que 
    //tu fais dans ta boucle for dans ton audiomanager
}
