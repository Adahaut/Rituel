using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTransform : MonoBehaviour
{
    private Transform target;
    
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (!target)
        {
            return;
        }
        
        transform.position = Vector3.Lerp(transform.position, target.position, 4f * Time.deltaTime);
    }
}
