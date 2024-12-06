using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkCore : MonoBehaviour
{
    public float linkCount { get; private set;}
    public float _maxLinkCount;
    private LinkAnimation linkAnimation;

    private void Start()
    {
        linkCount = 0;
        linkAnimation = GetComponent<LinkAnimation>();
        linkAnimation.StartLinkAnimation(true);
    }

    public void AddLink(int linkToAdd)
    {
        linkCount += linkToAdd;
        if (linkCount >= _maxLinkCount)
        {
            linkCount = _maxLinkCount;
        }
        linkAnimation.StartLinkAnimation(true);
    }

    public void RemoveLink(int LinkToRemove)
    {
        linkCount -= LinkToRemove;
        if (linkCount <= 0)
        {
            linkCount = 0;
        }

        linkAnimation.StartLinkAnimation(false);
    }
}
