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
        isRecording = true;
    }
    
    public void PlayNote(string Name)
    {
        //FindObjectOfType<AudioManager>().PlaySound(name);
        if (!isRecording) return;
        keys.Add(Name);
        if (partition[index] != keys[index])
        {
            Debug.Log("wrong key");
            if (partition.Count == keys.Count)
            {
                Debug.Log("enigma solved");
            }
            ResetEnigma();
            return;
        }
        index++;
        Debug.Log("good key");
    }

    private void ResetEnigma()
    {
        Debug.Log("reset enigma");
        isRecording = false;
        keys.Clear();
        timer = 0;
        index = 0;
    }
}
