using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enigmas.Ouija
{
    public abstract class OuijaCore: MonoBehaviour, IOuijaCore
    {
        [SerializeField] protected EnigmaData enigmaData;
        [field:SerializeField] public OuijaData _ouijaData { get; protected set; }
        [SerializeField] protected LinkCore linkCore;
        
        [SerializeField] protected OuijaBoard ouijaBoardPrefab;
        
        public Action OnGoodAnswerEvent;
        public Action OnBadAnswerEvent;
        
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
        
        protected abstract void OnGoodAnswer();
        protected abstract void OnBadAnswer();
    }
}