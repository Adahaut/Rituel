using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enigmas.Ouija
{
    public class OuijaCore : MonoBehaviour
    {
        [SerializeField] private EnigmaData enigmaData;
        [field:SerializeField] public WorldType _currentWorld { get; private set; }
        [field:SerializeField] public OuijaData _currentOuijaData { get; private set; }
        [field:SerializeField] public SerializedDictionary<char, OuijaCharacter> _characterObjects { get; private set; }
        public int _currentCharIndex { get; private set; }

        private void Awake()
        {
            DrawCharacters();
        }

        private void DrawCharacters()
        {
            foreach (char character in _characterObjects.Keys)
            {
                OuijaCharacter ouijaCharacter = _characterObjects[character];
                if (_currentWorld == WorldType.Human)
                {
                    ouijaCharacter._humanCharacter.gameObject.SetActive(true);
                    ouijaCharacter._spiritCharacter.gameObject.SetActive(false);
                }
                else
                {
                    ouijaCharacter._humanCharacter.gameObject.SetActive(false);
                    ouijaCharacter._spiritCharacter.gameObject.SetActive(true);
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