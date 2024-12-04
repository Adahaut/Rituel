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
    
    public void BeginRecord() //mauvais nom de fonction au vu du code
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
    
    public void PlayNote(string Name) //mauvais nom de fonction 
    {
        print(Name);
        FindObjectOfType<AudioManager>().PlayOneShot(Name);//audio manager par référence
        if (!isRecording) return;
        keys.Add(Name);
        if (partition.Count == keys.Count)
        {
            enigmaSolved = true;
            Debug.Log("enigma solved");
            ResetEnigma();
        }
        //pense à faire un "else if" sinon le programe va checker la condition même si la première est bonne
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
