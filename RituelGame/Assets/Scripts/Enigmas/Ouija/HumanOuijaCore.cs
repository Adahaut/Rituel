using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Enigmas.Ouija
{
    public class HumanOuijaCore : OuijaCore
    {
        [SerializeField] private OuijaHumanCursor humanCursor;
        
        [SerializeField] private Transform ouijaBoardLayoutParent;
        [SerializeField] private Transform ouijaBoardZoomedParent;
        [SerializeField] private List<OuijaBoard> spawnedOuijaBoards = new();

        private bool isZoomed;
        private bool canZoom = true;
        private int zoomedBoardLayoutIndex = 0;
        private Vector3 zoomedBoardOriginalScale;
        private OuijaBoard zoomedOuijaBoard;

        public Action OnUnzoomOuijaBoardEvent;
        public Action OnZoomOuijaBoardEvent;

        private void Awake()
        {
            SpawnAllOuijaBoards();
            DrawOuijaBoards();
            
            humanCursor.SetOuijaCore(this);
            OnUnzoomOuijaBoardEvent += humanCursor.StopMovement;

            OnGoodAnswerEvent += OnGoodAnswer;
            OnBadAnswerEvent += OnBadAnswer;
        }

        protected override void OnBadAnswer()
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
        }

        protected override void OnGoodAnswer()
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
            OuijaBoard newBoard = Instantiate(ouijaBoardPrefab, ouijaBoardLayoutParent);
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
        
        
        public void SetOuijaData(OuijaData ouijaData)
        {
            _ouijaData = ouijaData;
            DrawOuijaBoards();
        }

        public void OnBoardClicked(OuijaBoard ouijaBoardClicked)
        {
            if (isZoomed)
            {
                humanCursor.TryStartMovement(ouijaBoardClicked);
            }
            else
            {
                if (!canZoom)
                {
                    return;
                }

                Zoom(ouijaBoardClicked);
            }
        }

        private void Zoom(OuijaBoard ouijaBoardClicked)
        {
            isZoomed = true;
            zoomedOuijaBoard = ouijaBoardClicked;

            Transform zoomedOuijaBoardTransform = zoomedOuijaBoard.transform;
            zoomedBoardLayoutIndex = zoomedOuijaBoardTransform.GetSiblingIndex();
            zoomedOuijaBoardTransform.SetParent(ouijaBoardZoomedParent, true);
            zoomedBoardOriginalScale = zoomedOuijaBoardTransform.localScale;
                
            zoomedOuijaBoardTransform.DOMove(Vector3.zero, 1f).SetEase(Ease.InOutQuint);
            zoomedOuijaBoardTransform.DOScale(Vector3.one * 1, 1).SetEase(Ease.InOutQuint);

            var placeholderObject = new GameObject("ouijaBoardPlaceholder", typeof(RectTransform));
            placeholderObject.transform.SetParent(ouijaBoardLayoutParent);
            placeholderObject.transform.SetSiblingIndex(zoomedBoardLayoutIndex);

            CanvasGroup layoutCanvasGroup = ouijaBoardLayoutParent.GetComponent<CanvasGroup>();
            layoutCanvasGroup.DOFade(0, 1f);
            layoutCanvasGroup.SetCanvasGroupInteraction(false);
                
            OnZoomOuijaBoardEvent?.Invoke();
        }

        public void OnBackgroundClicked()
        {
            TryUnZoom();
        }

        public void TryUnZoom()
        {
            if (!isZoomed)
            {
                return;
            }

            UnZoom();
        }

        private void UnZoom()
        {
            isZoomed = false;
            canZoom = false;
            
            CanvasGroup layoutCanvasGroup = ouijaBoardLayoutParent.GetComponent<CanvasGroup>();
            layoutCanvasGroup.DOFade(1, 1f);
            layoutCanvasGroup.SetCanvasGroupInteraction(true);
            
            zoomedOuijaBoard.transform.DOScale(Vector3.one * 0.5f, 1).SetEase(Ease.InOutQuint);
            zoomedOuijaBoard.transform.DOMove(ouijaBoardLayoutParent.GetChild(zoomedBoardLayoutIndex).position, 1f)
                .SetEase(Ease.InOutQuint).onComplete += OnUnzoomFinished;
            
            OnUnzoomOuijaBoardEvent?.Invoke();
        }

        public void OnUnzoomFinished()
        {
            canZoom = true;

            Destroy(ouijaBoardLayoutParent.GetChild(zoomedBoardLayoutIndex).gameObject);
            
            zoomedOuijaBoard.transform.SetParent(ouijaBoardLayoutParent, true);
            zoomedOuijaBoard.transform.SetSiblingIndex(zoomedBoardLayoutIndex);
        }
    }
}