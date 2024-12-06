using System.Collections;
using TMPro;
using UnityEngine;

public class Vocals : MonoBehaviour
{
    private AudioSource source;

    [SerializeField] TextMeshProUGUI subtitleText;
    
    private void Awake()
    {
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
            subtitleText.text = subtitle.text;
            yield return new WaitForSeconds(subtitle.time);
        }
    }
}
