using System;
using Enum;
using TMPro;
using UnityEngine;

namespace Enigmas.Key
{
    public class SpiritKeyCore : MonoBehaviour, IKeyCore
    {
        [field:SerializeField] public KeyEnigmaData _keyEnigmaData { get; private set; }
        
        [SerializeField] public TextMeshProUGUI _keyValuesText;
        
        public void SetEnigmaData(KeyEnigmaData enigmaData)
        {
            _keyEnigmaData = enigmaData;
        }

        private void Awake()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            _keyValuesText.text = "";
            foreach (KeyTurnSide turnSide in _keyEnigmaData._sideTurnList)
            {
                string value = "";
                value = turnSide == KeyTurnSide.Right ? "Droite" : "Gauche";
                value += "\n";
                _keyValuesText.text += value;
            }
        }
    }
}