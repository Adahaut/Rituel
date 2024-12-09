using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
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

    public void Confirm()
    {
        if (String.Compare(_inputField.text.ToLower(), _answer.ToLower()) == 1)
        {
            _linkCore.AddLink(_cryptexData.LinkToAddIfSuccess);
            _checkCode.SetActive(false);
            _cryptexButton.SetActive(false);
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
