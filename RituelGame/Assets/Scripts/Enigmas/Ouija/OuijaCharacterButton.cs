using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Enigmas.Ouija
{
    public class OuijaCharacterButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private OuijaInputPanel ouijaInputPanel;
        private new RectTransform transform;
        private float baseScale;

        [SerializeField] private float scaleOnHover = 1.25f;

        private bool isInit;
        
        public void Init(OuijaInputPanel newOuijaInputPanel)
        {
            isInit = true;
            ouijaInputPanel = newOuijaInputPanel;
            transform = GetComponent<RectTransform>();
            baseScale = transform.localScale.x;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!isInit)
            {
                return;
            }
            transform.DOScale(scaleOnHover, 0.25f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!isInit)
            {
                return;
            }
            transform.DOScale(baseScale, 0.25f);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!isInit)
            {
                return;
            }
            ouijaInputPanel.RemoveChar(gameObject);
        }
    }
}