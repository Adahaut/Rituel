using UnityEngine;

[System.Serializable]
public struct _subtitles
{
    public float time;
    public string text;
}

[CreateAssetMenu(fileName = "New Subtitles", menuName = "Subtitles/SubtitlesData")]
public class Subtitles : ScriptableObject
{
    public _subtitles[] _subtitles;
    public AudioClip _audioClip;
}
