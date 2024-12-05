using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GameObject = UnityEngine.GameObject;

namespace Enigmas.Ouija
{
    public class OuijaInputPanel : MonoBehaviour
    {
        [SerializeField] private GameObject screenObjectPrefab;
        [field:SerializeField] private Transform inputScreen;
        [field:SerializeField] private Transform buttonHolder;
        private OuijaCore ouijaCore;
        private OuijaData ouijaData;

        [field: SerializeField] private int maxCharInput = 5;
        public List<char> _currentInput;
        
        private void Awake()
        {
            CreateInputList();
            ScreenSetup();
            AttachButtonListener();
        }

        private void CreateInputList()
        {
            _currentInput = new List<char>(maxCharInput);
        }

        public void SetOuijaCore(OuijaCore newOuijaCore)
        {
            ouijaCore = newOuijaCore;
            ouijaData = ouijaCore._currentOuijaData;
            RefreshButtons();
        }

        private void OnOuijaButtonClicked(char humanChar)
        {
            if (_currentInput.Count >= maxCharInput)
            {
                return;
            }
            _currentInput.Add(humanChar);
            RefreshScreen();
        }

        public void OnConfirmButtonClicked()
        {
            ouijaCore.OnConfirmAnswer(_currentInput);
        }

        public void OnEraseButtonClicked()
        {
            if (_currentInput.Count == 0)
            {
                return;
            }
            _currentInput.RemoveAt(_currentInput.Count - 1);
            RefreshScreen();
        }
        
        private void RefreshButtons()
        {
            var ouijaChars = ouijaData._ouijaCharacters.Keys;
            for (int i = 0; i < buttonHolder.childCount; i++)
            {
                OuijaButton ouijaButton = buttonHolder.GetChild(i).GetComponent<OuijaButton>();
                if (!ouijaButton)
                {
                    continue;
                }
                char charAtIndexI = ouijaChars.ElementAt(i);
                ouijaButton.SetOuijaSprite(charAtIndexI, ouijaData._fontAsset);
            }
        }
        
        private void RefreshScreen()
        {
            ResetScreen();
            for (int i = 0; i < _currentInput.Count; i++)
            {
                Transform inputScreenObject = inputScreen.GetChild(i);
                inputScreenObject.gameObject.SetActive(true);
                
                char humanChar = _currentInput[i];
                Sprite spiritChar = ouijaData._ouijaCharacters[humanChar];
                
                inputScreenObject.GetComponent<TextMeshProUGUI>().text = humanChar.ToString();
            }
        }

        private void ResetScreen()
        {
            foreach (Transform child in inputScreen)
            {
                child.gameObject.SetActive(false);
            }
        }
        
        private void AttachButtonListener()
        {
            for (int i = 0; i < buttonHolder.childCount; i++)
            {
                OuijaButton ouijaButton = buttonHolder.GetChild(i).GetComponent<OuijaButton>();
                if (!ouijaButton)
                {
                    continue;
                }

                ouijaButton.OnOuijaButtonClicked += OnOuijaButtonClicked;
            }
        }
        
        private void ScreenSetup()
        {
            foreach (Transform child in inputScreen)
            {
                Destroy(child.gameObject);
            }
            
            for (int i = 0; i < maxCharInput; i++)
            {
                GameObject screenObject = Instantiate(screenObjectPrefab, inputScreen);
                screenObject.SetActive(false);
            }
        }
    }
}