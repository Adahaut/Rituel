using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;
using UnityEngine.UI;

namespace Enigmas.Key
{
    public class SpiritKeyCore : MonoBehaviour, IKeyCore
    {
        [field:SerializeField] public KeyEnigmaData _keyEnigmaData { get; private set; }

        [SerializeField] private Transform turnInfoParent;
        [SerializeField] private KeyInputInfo turnInfoPrefab;
        
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
            List<KeyTurnSide> sideTurnList = _keyEnigmaData._sideTurnList;
            
            KeyTurnSide currentSide = sideTurnList[0];
            int sideAmount = 0;
            foreach (KeyTurnSide turnSide in sideTurnList)
            {
                if (turnSide != currentSide)
                {
                    AddInfo(currentSide, Mathf.Max(sideAmount, 1));
                    sideAmount = 1;
                    currentSide = turnSide;
                    continue;
                }
                sideAmount += 1;
            }
            AddInfo(currentSide, sideAmount);
            StartCoroutine(RebuildLayout());
        }

        private IEnumerator RebuildLayout()
        {
            yield return null;
            turnInfoParent.GetComponent<HorizontalLayoutGroup>().childScaleWidth = false;
            yield return null;
            turnInfoParent.GetComponent<HorizontalLayoutGroup>().childScaleWidth = true;
        }

        private void AddInfo(KeyTurnSide turnSide, int sideAmount)
        {
            KeyInputInfo newInfo = Instantiate(turnInfoPrefab, turnInfoParent);
            newInfo.SetInfo(turnSide, sideAmount);
            //LayoutRebuilder.ForceRebuildLayoutImmediate(turnInfoParent.GetComponent<RectTransform>());
        }
    }
}