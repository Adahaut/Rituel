using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckCodes : MonoBehaviour
{
    public EnigmaData _enigmaData;
    
    public LinkCore _linkCore;
    
    public TextMeshProUGUI _inputField;

    public string _answer;
    
    public GameObject _enigmaCanvas;
    public GameObject _buttonToAccessEnigma;

    public UnityEvent _onEnigmaFinished;

    public void Confirm()
    {
        string inputText = _inputField.text.ToLower();
        inputText = inputText.Remove(inputText.Length - 1);
        
        if (inputText.Equals(_answer.ToLower())) 
        {
            _linkCore.AddLink(_enigmaData.LinkToAddIfSuccess);
            _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            _enigmaCanvas.SetActive(false);
            _onEnigmaFinished.Invoke();
        }
        else
        {
            _linkCore.RemoveLink(_enigmaData.LinkToRemoveIfFail);
            _inputField.text = "";
        }
    }
}
