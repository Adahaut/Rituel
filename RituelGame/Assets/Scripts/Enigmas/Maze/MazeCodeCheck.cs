using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MazeCodeCheck : MonoBehaviour
{
    public EnigmaData _mazeData;
    
    public LinkCore _linkCore;
    
    public TextMeshProUGUI _inputField;

    public string _answer;
    
    public GameObject _mazeCanvas;
    public GameObject _maze;
    public GameObject _checkCode;
    public GameObject _buttonToAccessEnigma;

    public void Confirm()
    {
        if (String.Compare(_inputField.text.ToLower(), _answer.ToLower()) == 1)
        {
            _linkCore.AddLink(_mazeData.LinkToAddIfSuccess);
            _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            _mazeCanvas.SetActive(false);
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
        _maze.SetActive(true);
    }
}
