using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkCore : MonoBehaviour
{
    public float linkCount { get; private set;}
    public float _maxLinkCount;
    private LinkUI linkUI;

    private void Start()
    {
        linkCount = 40;
        linkUI = GetComponent<LinkUI>();
        linkUI.OnLinkChanged.Invoke();
    }

    public void AddLink(int linkToAdd)
    {
        linkCount += linkToAdd;
        if (linkCount >= _maxLinkCount)
        {
            linkCount = _maxLinkCount;
        }
        linkUI.OnLinkChanged.Invoke();
    }

    public void RemoveLink(int LinkToRemove)
    {
        linkCount -= LinkToRemove;
        if (linkCount <= 0)
        {
            linkCount = 0;
        }
        linkUI.OnLinkChanged.Invoke();
    }
}
