using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Cinematic
{
    public class CinematicController : MonoBehaviour, IPointerClickHandler
    {
        public string _humanScene;
        public string _spiritScene;
        
        [SerializeField] private List<CinematicEvent> cinematicEvents;
        private CinematicEvent currentEvent => cinematicEvents[cinematicIndex];

        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image oldBackgroundImage;
            
        private int cinematicIndex;

        private float autoPassTimer;

        private void Awake()
        {
            ApplyEvent();
        }

        private void Update()
        {
            AutoPassTimer();
        }

        private void AutoPassTimer()
        {
            if (!currentEvent._passAutomatically)
            {
                return;
            }
            
            autoPassTimer -= Time.deltaTime;
            if (autoPassTimer <= 0)
            {
                NextEvent();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!currentEvent._canBeClickedToPass)
            {
                return;
            }
            NextEvent();
        }

        private void NextEvent()
        {
            if (cinematicEvents.Count <= cinematicIndex + 1)
            {
                Debug.LogWarning("max cinematicEvent reached");
                return;
            }
            
            cinematicIndex++;
            ApplyEvent();
        }
        
        private void ApplyEvent()
        {
            CinematicEvent applyEvent = currentEvent;
            
            switch (applyEvent._eventType)
            {
                case CinematicEventType.ChangeBackground:
                    ChangeBackgroundEvent(applyEvent);
                    break;
                case CinematicEventType.ChangeScene:
                    ChangeSceneEvent(applyEvent);
                    break;
            }

            autoPassTimer = currentEvent._autoPassDuration;
            
        }

        private void ChangeSceneEvent(CinematicEvent applyEvent)
        {
            SceneManager.LoadScene(applyEvent._sceneName);
        }

        private void ChangeBackgroundEvent(CinematicEvent cinematicEvent)
        {
            oldBackgroundImage.sprite = backgroundImage.sprite;
            backgroundImage.sprite = cinematicEvent._backgroundSprite;
            backgroundImage.color = new Color() {r = 1, g = 1, b = 1, a = 0};
            backgroundImage.DOKill(false);
            backgroundImage.DOFade(1, cinematicEvent._fadeDuration);
        }
    }
}