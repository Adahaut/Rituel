using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Enigmas.Ouija
{
    public class OuijaCore : MonoBehaviour
    {
        [SerializeField] private EnigmaData enigmaData;
        [field:SerializeField] public OuijaData _currentOuijaData { get; private set; }
        public int _currentCharIndex { get; private set; }
        
        [field:SerializeField] public SerializedDictionary<char, Transform> _characterTransforms { get; private set; }

        private void Awake()
        {
            DrawCharacters();
        }

        private void DrawCharacters()
        {
            
        }

        public bool CheckAnswer(string answer)
        {
            return true;
        }
        
        public void SetOuijaData(OuijaData ouijaData)
        {
            _currentOuijaData = ouijaData;
            DrawCharacters();
        }
    }
}