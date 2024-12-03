using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Enigmas.Ouija
{
    public class OuijaCore : MonoBehaviour
    {
        [SerializeField] private EnigmaData enigmaData;
        [field:SerializeField] public WorldType _currentWorld { get; private set; }
        [field:SerializeField] public OuijaData _currentOuijaData { get; private set; }
        [field:SerializeField] public SerializedDictionary<char, OuijaCharacter> _characterTransforms { get; private set; }
        public int _currentCharIndex { get; private set; }

        private void Awake()
        {
            DrawCharacters();
        }

        private void DrawCharacters()
        {
            foreach (char character in _characterTransforms.Keys)
            {
                if (_currentWorld == WorldType.Human)
                {
                    
                }
                else
                {
                    
                }
            }
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