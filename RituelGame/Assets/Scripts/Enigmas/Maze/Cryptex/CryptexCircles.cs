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

    [SerializeField] private AudioManager audioManager;

    private void Start()
    {
        _cryptexDisplay.DisplayingText(_indexInValues);
    }

    public void IncrementValue()
    {
        audioManager.PlayOverlap("CryptexUp");
        if (_indexInValues == maxList)
        {
            _indexInValues = minList;
            return;
        }
        
        _indexInValues++;
    }
    
    public void DecrementValue()
    {
        audioManager.PlayOverlap("CryptexDown");
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
