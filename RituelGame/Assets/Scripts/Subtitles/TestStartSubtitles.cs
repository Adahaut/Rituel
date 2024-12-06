using UnityEngine;

public class TestStartSubtitle : MonoBehaviour
{
    public Subtitles _subtitlesToPlay;
    
    public void Start()
    {
        Vocals._instance.Say(_subtitlesToPlay);
    }
}