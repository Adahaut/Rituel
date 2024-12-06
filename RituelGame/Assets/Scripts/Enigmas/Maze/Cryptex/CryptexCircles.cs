using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexCircles : MonoBehaviour
{
    public CryptexDisplayingText _cryptexDisplay;
    
    public int _indexInValues;

    private void Start()
    {
        _cryptexDisplay.DisplayingText(_indexInValues);
    }

    public void IncrementValue()
    {
        if (_indexInValues == 11)
        {
            _indexInValues = 0;
            return;
        }
        
        _indexInValues++;
    }
    
    public void DecrementValue()
    {
        if (_indexInValues == 0)
        {
            _indexInValues = 11;
            return;
        }
        
        _indexInValues--;
    }

    public void ValueChanged()
    {
        _cryptexDisplay.DisplayingText(_indexInValues);
    }

    public int SendingValues()
    {
        return _indexInValues;
    }
}
