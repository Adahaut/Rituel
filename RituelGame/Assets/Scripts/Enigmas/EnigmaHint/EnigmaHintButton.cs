using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace Enigmas.EnigmaHint
{
    public class EnigmaHintButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private EnigmaData enigmaData;
        [SerializeField] private WorldType currentWorldType;
        
        [SerializeField] private SerializedDictionary<WorldType, Sprite> buttonSprites;
        
        public static Action<EnigmaData, WorldType> OnHintButtonClicked;

        [SerializeField] private SerializedDictionary<WorldType, Color> hoverFeedbackColors;
        [SerializeField] private List<Image> hoverFeedbackImages;

        public float timeCounter;
        private float timeLimit = 15;

        private bool didShow;

        private void Start()
        {
            Image image = gameObject.GetComponent<Image>();
            image.sprite = buttonSprites[currentWorldType];
            image.enabled = false;
            image.raycastTarget = false;
            foreach (var hoverImage in hoverFeedbackImages) { hoverImage.enabled = false; }
            didShow = false;

            foreach (var hoverImage in hoverFeedbackImages)
            {
                hoverImage.color = hoverFeedbackColors[currentWorldType];
            }
        }

        private void Update()
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= timeLimit && !didShow)
            {
                Image image = gameObject.GetComponent<Image>();
                image.enabled = true;
                image.raycastTarget = true;
                foreach (var hoverImage in hoverFeedbackImages) { hoverImage.enabled = true; }
                didShow = true;
            }
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnHintButtonClicked?.Invoke(enigmaData, currentWorldType);
        }
    }
}