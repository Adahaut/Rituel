using System;
using DG.Tweening;
using UnityEngine;

namespace Enigmas.Ouija
{
    public class OuijaHumanCursor : MonoBehaviour
    {
        private RectTransform rectTransform;
        private OuijaCore ouijaCore;
        private OuijaData ouijaData;
        
        [field:SerializeField] public Transform _baseCursorPosition { get; private set; }
        private OuijaBoard currentBoard;
        [field:SerializeField] public float _timeToNextPosition { get; private set; }
        [SerializeField] private Ease moveEase = Ease.InOutQuint;
        
        public int _currentCharIndex { get; private set; } = -1;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            rectTransform.position = _baseCursorPosition.position;
        }

        public void SetOuijaCore(OuijaCore newOuijaCore)
        {
            ouijaCore = newOuijaCore;
            ouijaData = ouijaCore._ouijaData;
        }

        public void TryStartMovement()
        {
            if (_currentCharIndex != -1)
            {
                return;
            }
            
            StartMovement();
        }

        private void StartMovement()
        {
            _currentCharIndex = -1;
            MoveToNextPosition();
        }

        private void MoveToNextPosition()
        {
            _currentCharIndex += 1;
            if (_currentCharIndex >= ouijaData._answerCharacters.Count)
            {
                _currentCharIndex = -1;
                rectTransform.DOMove(_baseCursorPosition.position, _timeToNextPosition).SetEase(moveEase);
                return;
            }

            char currentChar = ouijaData._answerCharacters[_currentCharIndex];
            OuijaCharacter currentCharacter = currentBoard._characterObjects[currentChar];
            rectTransform.DOMove(currentCharacter._rectTransform.position, _timeToNextPosition).
                SetEase(moveEase).onComplete += OnMovementCompleted;
        }

        private void OnMovementCompleted()
        {
            MoveToNextPosition();
        }
    }
}