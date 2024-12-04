using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HumainPiano : MonoBehaviour
{
    [SerializeField] private Partition scriptableObject; //le nom pas assez explicit
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
        //passe l'audio manager par référence
    }

    public void PlayMusic()
    {
        count = 0;
        StopAllCoroutines(); //non, stop seulement la coroutine que tu veux stoper
        StartCoroutine(musicSequence());
    }

    private IEnumerator musicSequence()
    {
        foreach (string unused in partition)
        {
            FindObjectOfType<AudioManager>().PlayOneShot(partition[count]);
            //pareil pour l'audio manager 
            yield return new WaitForSeconds(0.5f); //met une variable plutôt qu'une valeur direct
            count++;
        }
    }
}
