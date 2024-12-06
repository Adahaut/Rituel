using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CryptexLinkedCollider : MonoBehaviour
{
    public GameObject _linkedCircle;
    public CryptexRotation _cryptexRotation;
    public CryptexIncrement _cryptexIncrement;

    public int _cryptexNumber;
    private CryptexStruct _cryptexStruct;
    
    public float _circleRotation;

    private void Start()
    {
        _cryptexRotation = _linkedCircle.GetComponent<CryptexRotation>();
    }

    public void GetCryptexList(List<CryptexStruct> cryptexStructs)
    {
        _cryptexStruct = cryptexStructs[_cryptexNumber];
    }

    public void Rotation()
    {
        _cryptexRotation.Rotating(_circleRotation);

        if (_circleRotation > 0)
        {
            _cryptexIncrement.IncrementingValue(_cryptexStruct, _cryptexNumber);
        }
        else
        {
            _cryptexIncrement.DecrementingValue(_cryptexStruct, _cryptexNumber);
        }
    }
}
