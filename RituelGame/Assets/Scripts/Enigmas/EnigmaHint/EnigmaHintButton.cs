using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace Enigmas.EnigmaHint
{
    public class EnigmaHintButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private EnigmaData enigmaData;
        [SerializeField] private WorldType currentWorldType;
        
        public static Action<EnigmaData, WorldType> OnHintButtonClicked;

        public float timeCounter;
        private float timeLimit = 45;

        private bool didShow = false;

        private void Start()
        {
            Image image = gameObject.GetComponent<Image>();
            image.enabled = false;
            image.raycastTarget = false;
        }

        private void Update()
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= timeLimit && !didShow)
            {
                Image image = gameObject.GetComponent<Image>();
                image.enabled = true;
                image.raycastTarget = true;
                didShow = true;
            }
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnHintButtonClicked.Invoke(enigmaData, currentWorldType);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }
    }
}