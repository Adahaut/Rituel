using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumainPiano : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Partition partitionSO;
    private List<string> partition;
    //[SerializeField] private float minPitch;
    //[SerializeField] private float maxPitch;
    private float pitch;
    
    [SerializeField] private float timeBetweenNotes;
    private bool isMusicPlaying;
    private int count;
    

    private void Start()
    {
        partition = partitionSO.partitionKeys;
    }

    public void PlayMusic()
    {
        if (isMusicPlaying) return;
        count = 0;
        isMusicPlaying = true;
        StopCoroutine(musicSequence());
        StartCoroutine(musicSequence());
    }

    private IEnumerator musicSequence()
    {
        foreach (string unused in partition)
        {
            audioManager.PlayOverlap(partition[count]);
            yield return new WaitForSeconds(timeBetweenNotes);
            count++;
        }
        isMusicPlaying = false;
    }
}
