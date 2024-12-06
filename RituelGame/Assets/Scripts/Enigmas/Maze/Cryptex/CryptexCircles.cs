using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexCircles : MonoBehaviour
{
    public int _indexInValues;

    public void IncrementValue()
    {
        if (_indexInValues == 11)
        {
            _indexInValues = 0;
            Debug.Log(_indexInValues);
            return;
        }
        
        _indexInValues++;
        Debug.Log(_indexInValues);
    }
    
    public void DecrementValue()
    {
        if (_indexInValues == 0)
        {
            _indexInValues = 11;
            Debug.Log(_indexInValues);
            return;
        }
        
        _indexInValues--;
        Debug.Log(_indexInValues);
    }

    public int SendingValues()
    {
        return _indexInValues;
    }
}
