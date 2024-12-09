using System;
using UnityEngine;

namespace Enigmas.Ouija
{
    public class SpiritOuijaCore: OuijaCore
    {
        [SerializeField] private Transform ouijaBoardParent;
        
        private void Awake()
        {
            SpawnOuijaBoard();
            
            OnGoodAnswerEvent += OnGoodAnswer;
            OnBadAnswerEvent += OnBadAnswer;
        }

        private void SpawnOuijaBoard()
        {
            OuijaBoard newOuijaBoard = Instantiate(ouijaBoardPrefab, ouijaBoardParent);
        }

        protected override void OnGoodAnswer()
        {
            
        }

        protected override void OnBadAnswer()
        {
            
        }
    }
}