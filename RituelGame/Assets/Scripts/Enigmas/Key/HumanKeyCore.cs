using System;
using System.Collections.Generic;
using DG.Tweening;
using Enum;
using UnityEngine;

namespace Enigmas.Key
{
    public class HumanKeyCore : MonoBehaviour, IKeyCore
    {
        [field:SerializeField] public KeyEnigmaData _keyEnigmaData { get; private set; }
        [SerializeField] private EnigmaData enigmaData;
        [field:SerializeField] public TurnableKey _turnableKey { get; private set; }

        [SerializeField] private CanvasGroup closedChest;
        [SerializeField] private CanvasGroup openedChest;
        [SerializeField] private LinkCore linkCore;

        private List<KeyTurnSide> currentTurns = new();
        
        private void Awake()
        {
            _turnableKey.OnKeyFullLoopEvent += OnKeyTurned;
        }

        public void SetEnigmaData(KeyEnigmaData enigmaData)
        {
            _keyEnigmaData = enigmaData;
        }

        private void OnKeyTurned(KeyTurnSide side)
        {
            currentTurns.Add(side);
            List<KeyTurnSide> sideTurnList = _keyEnigmaData._sideTurnList;
            if (currentTurns.Count > sideTurnList.Count)
            {
                OnWrongTurn();
                return;
            }
            
            if (!AreTurnsCorrect())
            {
                OnWrongTurn();
                return;
            }

            if (currentTurns.Count == sideTurnList.Count)
            {
                OnCorrectAnswer();
            }
        }

        private void OnCorrectAnswer()
        {
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);
            closedChest.SetCanvasGroupInteraction(false);
            openedChest.SetCanvasGroupInteraction(true);
            closedChest.DOFade(0, 0.5f);
            openedChest.DOFade(1, 0.5f);
        }

        private void OnWrongTurn()
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
            currentTurns.Clear();
        }

        private bool AreTurnsCorrect()
        {
            bool result = true;
            List<KeyTurnSide> sideTurnList = _keyEnigmaData._sideTurnList;
            
            for (int i = 0; i < currentTurns.Count; i++)
            {
                if (currentTurns[i] != sideTurnList[i])
                {
                    result = false;
                    break;
                }
            }
            
            return result;
        }
    }
}