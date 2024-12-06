using UnityEngine;

public class TestStartSubtitle : MonoBehaviour
{
    public Subtitles _subtitlesToPlay;
    public Vocals _vocal;
    public void Start()
    {
        _vocal.Say(_subtitlesToPlay);
    }
}