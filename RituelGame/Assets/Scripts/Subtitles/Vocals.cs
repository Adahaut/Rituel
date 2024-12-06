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

    public void Say(Subtitles _subtitle)
    {
        if (source.isPlaying)
            source.Stop();
        
        source.PlayOneShot(_subtitle._audioClip);
        StartCoroutine(StartSubtitleCorroutine(_subtitle));
    }

    private IEnumerator StartSubtitleCorroutine(Subtitles _subtitle)
    {
        foreach (var subtitle in _subtitle._subtitles)
        {
            subtitleText.text = subtitle.text;
            yield return new WaitForSeconds(subtitle.time);
        }
    }
}
