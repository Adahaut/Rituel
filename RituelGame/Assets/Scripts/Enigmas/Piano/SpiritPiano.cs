using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritPiano : MonoBehaviour
{
    [SerializeField] private Partition scriptableObject;
    [SerializeField] private GameObject redDot;
    private List<string> partition;
    private List<string> keys = new List<string>();
    private int index;
    
    private bool isRecording;
    private bool enigmaSolved;

    private void Start()
    {
        partition = scriptableObject.partition;
    }
    
    public void BeginRecord()
    {
        isRecording = !isRecording;
        if (isRecording) {
            StartCoroutine(Flash());
        }
        else {
            StopCoroutine(Flash());
            redDot.SetActive(false);
        }
    }
    
    public void PlayNote(string Name)
    {
        print(Name);
        FindObjectOfType<AudioManager>().PlayOneShot(Name);
        if (!isRecording) return;
        keys.Add(Name);
        if (partition.Count == keys.Count)
        {
            enigmaSolved = true;
            Debug.Log("enigma solved");
            ResetEnigma();
        }
        if (partition.Count <= keys.Count && partition[index] != keys[index])
        {
            Debug.Log("wrong key");
            ResetEnigma();
            return;
        }
        index++;
        Debug.Log("good key");
    }

    private void ResetEnigma()
    {
        isRecording = false;
        keys.Clear();
        index = 0;
        if (!enigmaSolved)
        {
            Debug.Log("enigma lost");
        }
    }

    private IEnumerator Flash()
    {
        while (isRecording)
        {
            redDot.SetActive(true);
            yield return new WaitForSeconds(0.8f);
            redDot.SetActive(false);
            yield return new WaitForSeconds(0.8f);
        }
    }
}
