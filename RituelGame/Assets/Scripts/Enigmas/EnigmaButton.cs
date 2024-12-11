using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Enigmas
{
    public class EnigmaButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CanvasGroup enigmaCanvas;
        [SerializeField] private float canvasFadeDuration = 0.5f;


        private int _enigmaCounter;
        public int _enigmaNumber;
        
        public bool _canBeClicked;

        public bool _enigmaFinish = false;

        
        public Action OnButtonClickedEvent;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_canBeClicked)
            {
                enigmaCanvas.DOFade(1, 0.5f);
                enigmaCanvas.interactable = true;
                enigmaCanvas.blocksRaycasts = true;
                OnButtonClickedEvent?.Invoke();
            }
        }

        public void ActivateEnigma()
        {
            _canBeClicked = true;
        }

        public void FinalEnigma()
        {
            _enigmaCounter++;

            if (_enigmaCounter == _enigmaNumber)
            {
                _canBeClicked = true;
            }
            
            Debug.Log(_enigmaCounter);
        }
    }
}
