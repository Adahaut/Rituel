using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkCore : MonoBehaviour
{
    public float linkCount { get; private set;}
    public float _maxLinkCount;
    private LinkAnimation linkAnimation;
    [SerializeField] private AudioManager audioManager;
    
    [SerializeField] private Light light1;
    [SerializeField] private Light light2;
    private float currentIntensity;

    private void Start()
    {
        linkCount = 0;
        linkAnimation = GetComponent<LinkAnimation>();
        linkAnimation.StartLinkAnimation(true);
        light1.intensity = currentIntensity;
        light2.intensity = currentIntensity;
    }

    public void AddLink(int linkToAdd)
    {
        linkCount += linkToAdd;
        audioManager.PlayOverlap("AddLink");
        if (linkCount >= _maxLinkCount)
        {
            linkCount = _maxLinkCount;
        }
        linkAnimation.StartLinkAnimation(true);
    }

    public void RemoveLink(int LinkToRemove)
    {
        linkCount -= LinkToRemove;
        audioManager.PlayOverlap("LoseLink");
        if (linkCount <= 0)
        {
            linkCount = 0;
        }
        linkAnimation.StartLinkAnimation(false);
    }

    private void ManageLights()
    {
        if (linkCount >= 50)
        {
            currentIntensity = 1.5f;
        }
        light1.intensity = currentIntensity;
        light2.intensity = currentIntensity;
    }

    private IEnumerator FlashingLights(int flashNumber, float speed)
    {
        for (int i = 0; i < flashNumber; i++)
        {
            
            yield return new WaitForSeconds(speed);
        }
    }

    private void Update()
    {
        
    }
}
