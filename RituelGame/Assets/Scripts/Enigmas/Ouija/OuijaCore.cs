using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Enigmas.Ouija
{
    public class OuijaCore : MonoBehaviour
    {
        [SerializeField] private EnigmaData enigmaData;
        [field:SerializeField] public WorldType _currentWorld { get; private set; }
        [field:SerializeField] public OuijaData _ouijaData { get; private set; }
        [field:SerializeField] public OuijaCursor _ouijaCursor { get; private set; }
        [field:SerializeField] public OuijaBoard _ouijaBoard { get; private set; }
        [SerializeField] private LinkCore linkCore;
        
        
        public Action OnGoodAnswerEvent;
        public Action OnBadAnswerEvent;
        
        private void Awake()
        {
            _ouijaCursor.SetOuijaCore(this);
            _ouijaBoard.SetOuijaCore(this);
            _ouijaBoard.OnBoardClickedEvent += OnBoardClicked;
            DrawCharacters();
            if (_currentWorld == WorldType.Spirit)
            {
                _ouijaCursor.gameObject.SetActive(false);
            }

            OnGoodAnswerEvent += OnGoodAnswer;
            OnBadAnswerEvent += OnBadAnswer;
        }

        private void OnBadAnswer()
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
        }

        private void OnGoodAnswer()
        {
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);
        }

        private void DrawCharacters()
        {
            _ouijaBoard.DrawCharacters(_ouijaData._correctFontAsset);
        }
        
        public void OnConfirmAnswer(List<char> answer)
        {
            if (CheckResult(answer))
            {
                OnGoodAnswerEvent.Invoke();
            }
            else
            {
                OnBadAnswerEvent.Invoke();
            }
        }

        public bool CheckResult(List<char> answer)
        {
            bool result = answer.Count == _ouijaData._answerCharacters.Count;
            for (int i = 0; i < answer.Count; i++)
            {
                if (answer[i] == _ouijaData._answerCharacters[i]) continue;
                
                result = false;
                break;
            }
            
            return result;
        }
        
        public void SetOuijaData(OuijaData ouijaData)
        {
            _ouijaData = ouijaData;
            DrawCharacters();
        }

        public void OnBoardClicked()
        {
            _ouijaCursor.TryStartMovement();
        }

    }
}