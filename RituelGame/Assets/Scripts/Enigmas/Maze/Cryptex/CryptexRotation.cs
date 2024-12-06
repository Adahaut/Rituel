using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexRotation : MonoBehaviour
{
    public void Rotating(float angle)
    {
        transform.Rotate(new Vector3(0f, 1f, 0f), angle, Space.Self);
    }
}