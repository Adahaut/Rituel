using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Enigmas
{
    public class EnigmaBackButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CanvasGroup enigmaCanvas;
        [SerializeField] private float canvasFadeDuration = 0.5f;

        public Action OnButtonClickedEvent;
        
        public UnityEvent _onButtonClickedEvent;

        public void OnPointerClick(PointerEventData eventData)
        {
            enigmaCanvas.DOFade(0, canvasFadeDuration);
            enigmaCanvas.interactable = false;
            enigmaCanvas.blocksRaycasts = false;
            OnButtonClickedEvent?.Invoke();
            _onButtonClickedEvent?.Invoke();
        }
    }
}