using System.Collections;
using UnityEngine;

public class Vocals : MonoBehaviour
{
    private AudioSource source;
    public static Vocals _instance;

    private void Awake()
    {
        _instance = this;
        source = gameObject.AddComponent<AudioSource>();
    }

    public void Say(Subtitles _audioClip)
    {
        if (source.isPlaying)
            source.Stop();
        
        source.PlayOneShot(_audioClip._audioClip);
        StartCoroutine(StartSubtitleCorroutine(_audioClip));
    }

    private IEnumerator StartSubtitleCorroutine(Subtitles _audioClip)
    {
        foreach (var subtitle in _audioClip._subtitles)
        {
            SubtitleText._instance.SetSubtitle(subtitle.text);
            yield return new WaitForSeconds(subtitle.time);
        }
    }
}
