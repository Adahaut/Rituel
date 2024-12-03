using System;
using System.Collections.Generic;
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
        [field:SerializeField] public OuijaCursor _ouijaCursor { get; private set; }
        [field:SerializeField] public OuijaInputPanel _ouijaInputPanel { get; private set; }
        [field:SerializeField] public OuijaBoard _ouijaBoard { get; private set; }

        private void Awake()
        {
            _ouijaCursor.SetOuijaCore(this);
            _ouijaBoard.SetOuijaCore(this);
            DrawCharacters();
            if (_currentWorld == WorldType.Spirit)
            {
                _ouijaInputPanel.SetOuijaCore(this);
                _ouijaCursor.gameObject.SetActive(false);
            }
        }

        private void DrawCharacters()
        {
            _ouijaBoard.DrawCharacters();
        }
        
        public bool CheckAnswer(List<char> answer)
        {
            bool result = true;
            if (answer.Count != _currentOuijaData._answerCharacters.Count)
            {
                result = false;
                Debug.Log($"The answer is {result}");
                return result;
            }
            for (int i = 0; i < answer.Count; i++)
            {
                if (answer[i] == _currentOuijaData._answerCharacters[i]) continue;
                
                result = false;
                break;
            }
            
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