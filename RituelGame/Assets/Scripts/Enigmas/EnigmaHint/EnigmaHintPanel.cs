using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Enigmas.EnigmaHint
{
    public class EnigmaHintPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        private CanvasGroup panelGroup;
        
        private EnigmaData enigmaData;

        private bool isOpened;
        
        private void Awake()
        {
            panelGroup = GetComponent<CanvasGroup>();
            EnigmaHintButton.OnHintButtonClicked += OnHintButtonClicked;
        }

        private void OnHintButtonClicked(EnigmaData newEnigmaData, WorldType currentWorldType)
        {
            if (isOpened)
            {
                return;
            }
            enigmaData = newEnigmaData;
            text.text = enigmaData.EnigmaHint[currentWorldType];
            OpenHintPanel();
        }

        public void OpenHintPanel()
        {
            isOpened = true;
            panelGroup.DOFade(1, 0.5f);
            panelGroup.SetCanvasGroupInteraction(true);
        }

        public void CloseHintPanel()
        {
            isOpened = false;
            panelGroup.DOFade(0, 0.5f);
            panelGroup.SetCanvasGroupInteraction(false);
        }
    }
}