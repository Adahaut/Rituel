using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexCircles : MonoBehaviour
{
    public CryptexDisplayingText _cryptexDisplay;
    
    public int _indexInValues;
    
    private int minList = 0;
    private int maxList = 11;

    private void Start()
    {
        _cryptexDisplay.DisplayingText(_indexInValues);
    }

    public void IncrementValue()
    {
        if (_indexInValues == maxList)
        {
            _indexInValues = minList;
            return;
        }
        
        _indexInValues++;
    }
    
    public void DecrementValue()
    {
        if (_indexInValues == minList)
        {
            _indexInValues = maxList;
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
