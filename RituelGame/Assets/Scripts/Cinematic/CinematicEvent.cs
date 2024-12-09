using System;
using UnityEditor;
using UnityEngine;

namespace Cinematic
{
    [Serializable]
    public class CinematicEvent
    {
        public CinematicEventType _eventType;
        
        [Header("Pass Event Conditions")]
        public bool _canBeClickedToPass;
        
        public bool _passAutomatically;
        public float _autoPassDuration;
        
        [Header("Specific: ChangeBackground Event")]
        public Sprite _backgroundSprite;
        public float _fadeDuration;
        
        [Header("Specific: ChangeScene Event")]
        public string _sceneName;
        
        [Header("Specific: Play sound Event")]
        public string _audioName;
    }
    
}