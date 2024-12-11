using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class CanvasGroupFader : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    [SerializeField] private float fadeTime = 1;
    
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public Tween ShowCanvas()
    {
        canvasGroup.SetCanvasGroupInteraction(true);
        return canvasGroup.DOFade(1, fadeTime);
    }

    public Tween HideCanvas()
    {
        canvasGroup.SetCanvasGroupInteraction(false);
        return canvasGroup.DOFade(0, fadeTime);
    }

    public void HideThenShowAnother(GameObject nextFader)
    {
        HideCanvas().onComplete += () => { nextFader.GetComponent<CanvasGroupFader>().ShowCanvas(); };
    }
}
