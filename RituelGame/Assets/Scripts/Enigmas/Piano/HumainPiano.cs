using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HumainPiano : MonoBehaviour
{
    [SerializeField] private Partition scriptableObject;
    private List<string> partition;
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;
    private float pitch;
    private int count;
    

    private void Start()
    {
        partition = scriptableObject.partition;
        pitch = Random.Range(minPitch, maxPitch);
        FindObjectOfType<AudioManager>().ChangePitch("PianoMusic", pitch);
    }

    public void PlayMusic()
    {
        count = 0;
        StopAllCoroutines();
        StartCoroutine(musicSequence());
    }

    private IEnumerator musicSequence()
    {
        foreach (string unused in partition)
        {
            FindObjectOfType<AudioManager>().PlaySound(partition[count]);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
    }
}
