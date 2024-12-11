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

    private void Start()
    {
        linkCount = 0;
        linkAnimation = GetComponent<LinkAnimation>();
        linkAnimation.StartLinkAnimation(true);
    }

    public void AddLink(int linkToAdd)
    {
        linkCount += linkToAdd;
        audioManager.PlaySound("AddLink");
        if (linkCount >= _maxLinkCount)
        {
            linkCount = _maxLinkCount;
        }
        linkAnimation.StartLinkAnimation(true);
    }

    public void RemoveLink(int LinkToRemove)
    {
        linkCount -= LinkToRemove;
        audioManager.PlaySound("LoseLink");
        if (linkCount <= 0)
        {
            linkCount = 0;
        }
        linkAnimation.StartLinkAnimation(false);
    }
}
