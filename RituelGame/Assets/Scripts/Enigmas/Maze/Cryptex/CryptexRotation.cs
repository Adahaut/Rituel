using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class CryptexRotation : MonoBehaviour
{
    public CryptexCircles _cryptexCircles;

    public float _rotateAngle;

    private Vector3 circleRot;
    
    public void Rotating()
    {
        transform.rotation = Quaternion.Euler(new Vector3(_rotateAngle * _cryptexCircles._indexInValues -7.5f, 0.0f, 90f));
    }
}
