using System;
using UnityEngine;

namespace Enigmas.Ouija
{
    public class SpiritOuijaCore: OuijaCore
    {
        [SerializeField] private Transform ouijaBoardParent;

        public GameObject _codePanel;
        public GameObject _enigma;
        
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
            Debug.Log("good");
        }

        protected override void OnBadAnswer()
        {
            Debug.Log("Bad");
        }
    }
}