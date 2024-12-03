using System.Collections.Generic;
using UnityEngine;

public class SpiritPiano : MonoBehaviour
{
    [SerializeField] private Partition scriptableObject;
    [SerializeField] private float maxTime;
    private List<string> partition;
    private List<string> keys = new List<string>();
    private float timer;
    private int index;
    
    private bool isRecording;
    private bool enigmaSolved;

    private void Start()
    {
        partition = scriptableObject.partition;
    }

    private void Update()
    {
        if (!isRecording) return;
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            ResetEnigma();
        }
    }

    public void BeginRecord()
    {
        if (!isRecording)
        {
            isRecording = true;
        }
    }
    
    public void PlayNote(string Name)
    {
        print(Name);
        FindObjectOfType<AudioManager>().PlaySound(Name);
        if (!isRecording) return;
        keys.Add(Name);
        if (partition.Count == keys.Count)
        {
            enigmaSolved = true;
            Debug.Log("enigma solved");
        }
        if (partition[index] != keys[index])
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
        timer = 0;
        index = 0;
        if (!enigmaSolved)
        {
            Debug.Log("enigma lost");
        }
    }
}
