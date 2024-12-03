using UnityEngine;
using Random = UnityEngine.Random;

public class HumainPiano : MonoBehaviour
{
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;
    private float pitch;

    private void Start()
    {
        pitch = Random.Range(minPitch, maxPitch);
        FindObjectOfType<AudioManager>().ChangePitch("PianoMusic", pitch);
    }

    public void PlayMusic()
    {
        FindObjectOfType<AudioManager>().PlaySound("PianoMusic");
    }
}
