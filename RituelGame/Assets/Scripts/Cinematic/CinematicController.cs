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

        public float _autoPassTimer;
        
        public Subtitles _subtitlesToPlay;
        public Vocals _vocalsScript;
        private int subtitleIndex=0;
        private void Awake()
        {
            ApplyEvent();
        }

        private void Start()
        {
            _vocalsScript.Say(_subtitlesToPlay);
            _autoPassTimer = _subtitlesToPlay._subtitles[subtitleIndex].time;
        }

        private void Update()
        {
            AutoPassTimer();
        }

        private void AutoPassTimer()
        {
                        
            _autoPassTimer -= Time.deltaTime;
            if (_autoPassTimer <= 0)
            {
                NextEvent();
            }
            
            if (!currentEvent._passAutomatically)
            {
                return;
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
            subtitleIndex++;
            cinematicIndex++;
            _autoPassTimer = _subtitlesToPlay._subtitles[subtitleIndex].time;
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

            // autoPassTimer = currentEvent._autoPassDuration;
            
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