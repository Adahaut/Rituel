using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpiritPiano : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Partition partitionSO;
    [SerializeField] private GameObject redDot;
    private List<string> partition;
    private List<string> keys = new List<string>();
    private int index;
    
    private bool isRecording;
    private bool enigmaSolved;

    private void Start()
    {
        partition = partitionSO.partitionKeys;
    }
    
    public void RecordButton()
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
    
    public void EnigmaLogic(string Name)
    {
        audioManager.PlayOverlap(Name);
        if (!isRecording) return;
        keys.Add(Name);
        if (partition.Count == keys.Count && partition[index] == keys[index])
        {
            Debug.Log("enigma solved");
            enigmaSolved = true;
            ResetEnigma();
            return;
        }
        else if (partition[index] != keys[index])
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
