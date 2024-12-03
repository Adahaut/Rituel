using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LinkUI : MonoBehaviour
{
    public UnityEvent OnLinkChanged {private set; get;}
    public Slider _linkSlider;
    public TextMeshProUGUI _linkText;
    private LinkCore linkCore;
    
    private void Start()
    {
        linkCore = GetComponent<LinkCore>();
        OnLinkChanged = new UnityEvent();
        OnLinkChanged.AddListener(UpdateLinkSlider);
    }

    private void UpdateLinkSlider()
    {
        _linkSlider.value = linkCore.linkCount / linkCore._maxLinkCount;
        _linkText.text = linkCore.linkCount.ToString() + "%";
    }
}
