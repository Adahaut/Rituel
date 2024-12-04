using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class HumainPiano : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Partition partitionSO;
    private List<string> partition;
    [SerializeField] private float minPitch;
    [SerializeField] private float maxPitch;
    private float pitch;
    [SerializeField] private float timeBetweenNotes;
    private int count;
    

    private void Start()
    {
        partition = partitionSO.partitionKeys;
        pitch = Random.Range(minPitch, maxPitch);
    }

    public void PlayMusic()
    {
        count = 0;
        StopCoroutine(musicSequence());
        StartCoroutine(musicSequence());
    }

    private IEnumerator musicSequence()
    {
        foreach (string unused in partition)
        {
            audioManager.PlayOverlap(partition[count]);
            audioManager.ChangePitch(partition[count], pitch);
            yield return new WaitForSeconds(timeBetweenNotes);
            count++;
        }
    }
}
