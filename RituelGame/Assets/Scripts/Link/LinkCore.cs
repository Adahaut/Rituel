using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class LinkCore : MonoBehaviour
{
    public float linkCount { get; private set;}
    public float _maxLinkCount;
    private LinkAnimation linkAnimation;
    [SerializeField] private AudioManager audioManager;
    
    [SerializeField] private Light2D light1;
    [SerializeField] private Light2D light2;
    private float currentIntensity;
    
    public float minInterval = 0.1f; 
    public float maxInterval = 1.0f; 
    public float minIntensity = 0.0f;

    private bool isBlinking = false;

    private void Start()
    {
        linkCount = 0;
        linkAnimation = GetComponent<LinkAnimation>();
        linkAnimation.StartLinkAnimation(true);
        light1.intensity = currentIntensity;
        light2.intensity = currentIntensity;
        ManageLights();
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
        ManageLights();
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
        ManageLights();
    }

    private void ManageLights()
    {
        currentIntensity = Mathf.Clamp(2 * (linkCount / 50), 0.1f, 2f);
        light1.intensity = currentIntensity;
        light2.intensity = currentIntensity;
    }

    private IEnumerator FlickerLights(int NbOfFlicker)
    {
        isBlinking = true;
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < NbOfFlicker; i++)
        {
            float randomInterval = Random.Range(minInterval, maxInterval);
            float randomIntensity = Random.Range(minIntensity, currentIntensity);

            audioManager.PlayOverlap("Flickering");
            light1.intensity = randomIntensity;
            light2.intensity = randomIntensity;
            yield return new WaitForSeconds(randomInterval);
        }
        ManageLights();
    }

    private void Update()
    {
        if (isBlinking == false)
        {
            StartCoroutine(FlickerLights(7));
        }
    }
}
