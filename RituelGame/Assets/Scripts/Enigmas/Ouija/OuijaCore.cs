using System;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Enigmas.Ouija
{
    public class OuijaCore : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private EnigmaData enigmaData;
        [field:SerializeField] public WorldType _currentWorld { get; private set; }
        [field:SerializeField] public OuijaData _currentOuijaData { get; private set; }
        [field:SerializeField] public SerializedDictionary<char, OuijaCharacter> _characterObjects { get; private set; }
        [field:SerializeField] public OuijaCursor _ouijaCursor { get; private set; }
        [field:SerializeField] public OuijaInputPanel _ouijaInputPanel { get; private set; }

        private void Awake()
        {
            _ouijaCursor.SetOuijaCore(this);
            _ouijaInputPanel.SetOuijaCore(this);
            DrawCharacters();
            if (_currentWorld == WorldType.Spirit)
            {
                _ouijaCursor.gameObject.SetActive(false);
            }
            else
            {
                _ouijaInputPanel.gameObject.SetActive(false);
            }
        }

        private void DrawCharacters()
        {
            foreach (OuijaCharacter ouijaCharacter in _characterObjects.Keys.Select(character => _characterObjects[character]))
            {
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
            bool result = true;
            
            
            Debug.Log($"The answer is {result}");
            return result;
        }
        
        public void SetOuijaData(OuijaData ouijaData)
        {
            _currentOuijaData = ouijaData;
            DrawCharacters();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _ouijaCursor.TryStartMovement();
        }

    }
}