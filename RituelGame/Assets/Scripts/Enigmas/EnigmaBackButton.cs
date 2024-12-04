using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnigmaBackButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CanvasGroup enigmaCanvas;
    [SerializeField] private float canvasFadeDuration = 0.5f;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        enigmaCanvas.DOFade(0, canvasFadeDuration);
        enigmaCanvas.interactable = false;
        enigmaCanvas.blocksRaycasts = false;
    }
}
