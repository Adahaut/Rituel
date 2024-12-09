using UnityEngine;

public class TestStartSubtitle : MonoBehaviour
{
    public Subtitles _subtitlesToPlay;
    public Vocals _vocalsScript;
    public void Start()
    {
        _vocalsScript.Say(_subtitlesToPlay);
    }
}