using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckCodes : MonoBehaviour
{
    public EnigmaData _enigmaData;
    
    public LinkCore _linkCore;
    
    public TextMeshProUGUI _inputField;

    public string _answer;
    
    public GameObject _enigmaCanvas;
    public GameObject _buttonToAccessEnigma;

    public void Confirm()
    {
        if (String.Compare(_inputField.text.ToLower(), _answer.ToLower()) == 1)
        {
            _linkCore.AddLink(_enigmaData.LinkToAddIfSuccess);
            _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            _enigmaCanvas.SetActive(false);
        }
        else
        {
            _linkCore.RemoveLink(_enigmaData.LinkToRemoveIfFail);
            _inputField.text = "";
        }
    }
}
