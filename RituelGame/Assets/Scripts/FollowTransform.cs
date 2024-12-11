using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FollowTransform : MonoBehaviour
{
    private Transform target;

    private Vector3 targetPosition;
    
    public float floatAmount = 0;
    private Vector3 offsetPosition;
    private float randomSeed;

    private void Awake()
    {
        GenerateSeed();
        InvokeRepeating(nameof(GenerateSeed), 0, 1);
    }

    private void GenerateSeed()
    {
        randomSeed = Random.Range(-1000, 1000);
    }

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
        
        targetPosition = target.position;
        
        offsetPosition.y = Mathf.Lerp(offsetPosition.y, floatAmount * Mathf.Sin((randomSeed + Time.time) * 2f), 4 * Time.deltaTime);
        offsetPosition.x =  Mathf.Lerp(offsetPosition.y, floatAmount * Mathf.Sin((-randomSeed + Time.time) * 2f), 4 * Time.deltaTime);
        
        targetPosition += offsetPosition;
        
        transform.position = Vector3.Lerp(transform.position, targetPosition, 4f * Time.deltaTime);
    }
}
