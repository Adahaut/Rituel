using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Enigmas
{
    public class EnigmaButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CanvasGroup enigmaCanvas;
        [SerializeField] private float canvasFadeDuration = 0.5f;

        public Sprite _unlockedSprite;

        private int _enigmaCounter;
        public int _enigmaNumber;
        
        public bool _canBeClicked;

        public bool _enigmaFinish = false;
        
        public Action OnButtonClickedEvent;
        
        public UnityEvent _onButtonClicked;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_canBeClicked)
            {
                enigmaCanvas.DOFade(1, 0.5f);
                enigmaCanvas.interactable = true;
                enigmaCanvas.blocksRaycasts = true;
                OnButtonClickedEvent?.Invoke();
                _onButtonClicked.Invoke();
            }
        }

        public void ActivateEnigma()
        {
            if (_unlockedSprite)
            {
                gameObject.GetComponent<Image>().sprite = _unlockedSprite;
            }
            _canBeClicked = true;
        }

        public void FinalEnigma()
        {
            _enigmaCounter++;

            if (_enigmaCounter == _enigmaNumber)
            {
                _canBeClicked = true;
            }
        }
    }
}
