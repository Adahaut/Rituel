using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Enigmas.Ouija
{
    public class OuijaCore : MonoBehaviour, IOuijaCore
    {
        [SerializeField] private EnigmaData enigmaData;
        [field:SerializeField] public WorldType _currentWorld { get; private set; }
        [field:SerializeField] public OuijaData _ouijaData { get; private set; }
        [SerializeField] private LinkCore linkCore;

        [SerializeField] private OuijaBoard ouijaBoardPrefab;
        [SerializeField] private Transform ouijaBoardParent;
        [SerializeField] private List<OuijaBoard> spawnedOuijaBoards = new();
        
        public Action OnGoodAnswerEvent;
        public Action OnBadAnswerEvent;

        private void Awake()
        {
            SpawnAllOuijaBoards();
            DrawOuijaBoards();

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

        private void SpawnAllOuijaBoards()
        {
            for (int i = 0; i < _ouijaData._falseFontAssets.Count + 1; i++) //+1 for the correct font too
            {
                SpawnOuijaBoard();
            }
        }

        private void SpawnOuijaBoard()
        {
            OuijaBoard newBoard = Instantiate(ouijaBoardPrefab, ouijaBoardParent);
            newBoard.SetOuijaCore(this);
            newBoard.OnBoardClickedEvent += OnBoardClicked;
            spawnedOuijaBoards.Add(newBoard);
        }
        
        private void DrawOuijaBoards()
        {
            List<TMP_FontAsset> fontAssets = new();
            fontAssets.Add(_ouijaData._correctFontAsset);
            fontAssets.AddRange(_ouijaData._falseFontAssets.ToList());
            foreach (OuijaBoard currentBoard in spawnedOuijaBoards)
            {
                int randomIndex = Random.Range(0, fontAssets.Count);
                TMP_FontAsset chosenFontAsset = fontAssets[randomIndex];
                fontAssets.Remove(chosenFontAsset);
                currentBoard.DrawCharacters(chosenFontAsset);
            }
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
            DrawOuijaBoards();
        }

        public void OnBoardClicked(OuijaBoard ouijaBoardClicked)
        {
            
        }
    }
}