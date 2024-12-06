using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct CryptexStruct
{
    public List<char> values;
    public int valueIndex;
}

public class CryptexValue : MonoBehaviour
{
    public List<char> circlesValues = new();
    
    public CryptexStruct firstCircle = new();
    public CryptexStruct secondCircle = new();
    public CryptexStruct thirdCircle = new();
    public CryptexStruct fourthCircle = new();
    public CryptexStruct fifthCircle = new();
    
    public CryptexIncrement _cryptexIncrement;
    
    public UnityEvent<CryptexStruct> onStructAdded;
    
    private void Start()
    {
        InitStructCryptex(firstCircle, circlesValues, 0);
        InitStructCryptex(secondCircle, circlesValues, 0);
        InitStructCryptex(thirdCircle, circlesValues, 0);
        InitStructCryptex(fourthCircle, circlesValues, 0);
        InitStructCryptex(fifthCircle, circlesValues, 0);
    }

    private void InitStructCryptex(CryptexStruct cryptexStruct, List<char> circlesValues, int valueIndex)
    {
        cryptexStruct.values = circlesValues;
        cryptexStruct.valueIndex = valueIndex;
        
        onStructAdded.Invoke(cryptexStruct);
    }
}
