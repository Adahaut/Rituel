using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PostProcessHandler : MonoBehaviour
{
    private Volume volume;

    private void Awake()
    {
        volume = GetComponent<Volume>();
    }

    public void ActivatePostProcess()
    { 
        volume.weight = 1;
    }

    public void DisablePostProcess()
    { 
        volume.weight = 0;
    }
}
