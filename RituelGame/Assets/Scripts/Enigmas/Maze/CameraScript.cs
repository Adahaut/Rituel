using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float gridLenght;
    
    void Start()
    {
        transform.position = new Vector3(gridLenght/2, gridLenght/2, -10f);
    }
}
