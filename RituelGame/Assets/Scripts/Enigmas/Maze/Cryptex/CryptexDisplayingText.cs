using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CryptexDisplayingText : MonoBehaviour
{
    public EnigmaCryptexCore _cryptexCore;
    
    public List<char> texts = new();
    public List<TextMeshProUGUI> _textsDisplay = new();
    
    private int minList = 0;
    private int maxList = 11;

    void Start()
    {
        texts = _cryptexCore.values;
    }

    public void DisplayingText(int textIndex)
    {
        if(textIndex == minList)
            _textsDisplay[0].text = texts[maxList].ToString();
        else 
            _textsDisplay[0].text = texts[textIndex - 1].ToString();
        
        _textsDisplay[1].text = texts[textIndex].ToString();
        
        if(textIndex == maxList)
            _textsDisplay[2].text = texts[minList].ToString();
        else
            _textsDisplay[2].text = texts[textIndex + 1].ToString();
    }
}
