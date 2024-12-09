using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MazeCodeCheck : MonoBehaviour
{
    public EnigmaData _mazeData;
    
    public LinkCore _linkCore;
    
    public TextMeshProUGUI _inputField;

    public string _answer;
    
    public GameObject _mazeCanvas;
    public GameObject _checkCode;
    public GameObject _mazeButton;

    public void Confirm()
    {
        if (String.Compare(_inputField.text.ToLower(), _answer.ToLower()) == 1)
        {
            _linkCore.AddLink(_mazeData.LinkToAddIfSuccess);
            _checkCode.SetActive(false);
            _mazeButton.SetActive(false);
        }
        else
        {
            _linkCore.RemoveLink(_mazeData.LinkToRemoveIfFail);
            _inputField.text = "";
        }
    }

    public void Cancel()
    {
        _checkCode.SetActive(false);
        _mazeCanvas.SetActive(true);
    }
}
