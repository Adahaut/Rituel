using System;
using System.Collections;
using System.Collections.Generic;
using Enigmas;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CryptexCheckCodeScript : MonoBehaviour
{
    public EnigmaData _cryptexData;
    
    public LinkCore _linkCore;
    
    public TextMeshProUGUI _inputField;

    public string _answer;
    
    public GameObject _cryptexCanvas;
    public GameObject _checkCode;
    public GameObject _cryptexButton;

    public UnityEvent _onEngimaFinished;

    public void Confirm()
    {
        string inputText = _inputField.text.ToLower();
        inputText = inputText.Remove(inputText.Length - 1);
        
        if (inputText.Equals(_answer.ToLower()))
        {
            _linkCore.AddLink(_cryptexData.LinkToAddIfSuccess);
            _checkCode.SetActive(false);
            _cryptexButton.GetComponent<EnigmaButton>()._canBeClicked = false;
            _cryptexButton.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            _onEngimaFinished.Invoke();
        }
        else
        {
            _linkCore.RemoveLink(_cryptexData.LinkToRemoveIfFail);
            _inputField.text = "";
        }
    }

    public void Cancel()
    {
        _checkCode.SetActive(false);
        _cryptexCanvas.SetActive(true);
    }
}
