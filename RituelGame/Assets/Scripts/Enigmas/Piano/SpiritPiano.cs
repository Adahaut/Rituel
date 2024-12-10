using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

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

    [SerializeField] private LinkCore linkCore;
    [SerializeField] private EnigmaData enigmaData;

    public GameObject _buttonToAccessEnigma;
    public GameObject _codePanel;
    public GameObject _pianoObject;

    public UnityEvent _onEnigmaSolved;
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
            //if enigma solved
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);
            enigmaSolved = true;
            ResetEnigma();
            _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            _pianoObject.SetActive(false);
            _codePanel.SetActive(true);
            _onEnigmaSolved.Invoke();
            return;
        }
        else if (partition[index] != keys[index])
        {
            //if wrong key 
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
            ResetEnigma();
            return;
        }
        index++;
        //if good key
    }

    private void ResetEnigma()
    {
        isRecording = false;
        keys.Clear();
        index = 0;
        if (!enigmaSolved)
        {
            //enigma lost
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
