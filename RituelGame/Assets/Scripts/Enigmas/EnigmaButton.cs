using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Enigmas
{
    public class EnigmaButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CanvasGroup enigmaCanvas;
        [SerializeField] private float canvasFadeDuration = 0.5f;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            enigmaCanvas.DOFade(1, 0.5f);
            enigmaCanvas.interactable = true;
            enigmaCanvas.blocksRaycasts = true;
        }
    }
}
