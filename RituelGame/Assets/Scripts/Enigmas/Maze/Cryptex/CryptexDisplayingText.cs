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

    void Start()
    {
        texts = _cryptexCore.values;
    }

    public void DisplayingText(int textIndex)
    {
        if(textIndex == 0)
            _textsDisplay[0].text = texts[11].ToString();
        else 
            _textsDisplay[0].text = texts[textIndex - 1].ToString();
        
        _textsDisplay[1].text = texts[textIndex].ToString();
        
        if(textIndex == 11)
            _textsDisplay[2].text = texts[0].ToString();
        else
            _textsDisplay[2].text = texts[textIndex + 1].ToString();
    }
}
