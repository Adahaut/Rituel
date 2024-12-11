﻿using System;
using UnityEngine;
using UnityEngine.Events;

namespace Enigmas.Ouija
{
    public class SpiritOuijaCore: OuijaCore
    {
        [SerializeField] private Transform ouijaBoardParent;

        public GameObject _codePanel;
        public GameObject _enigma;


        public UnityEvent _onEnigmaCompleted;

        public GameObject _buttonToAccessEnigma;

        
        private void Awake()
        {
            SpawnOuijaBoard();
            
            OnGoodAnswerEvent += OnGoodAnswer;
            OnBadAnswerEvent += OnBadAnswer;
        }

        private void SpawnOuijaBoard()
        {
            OuijaBoard newOuijaBoard = Instantiate(ouijaBoardPrefab, ouijaBoardParent);
            newOuijaBoard.SetOuijaCore(this);
            newOuijaBoard.DrawCharacters(_ouijaData._correctFontAsset);
        }

        protected override void OnGoodAnswer()
        {
            _codePanel.SetActive(true);
            _enigma.SetActive(false);
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);

            _onEnigmaCompleted.Invoke();

            _buttonToAccessEnigma.GetComponent<EnigmaButton>()._enigmaFinish = true;

        }

        protected override void OnBadAnswer()
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
        }
    }
}