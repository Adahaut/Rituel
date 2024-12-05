using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Enigmas.Ouija
{
    public class OuijaButton : MonoBehaviour
    {
        private char character;
        public Action<char> OnOuijaButtonClicked;

        public void SetOuijaSprite(char humanChar,TMP_FontAsset ouijaFontAsset)
        {
            character = humanChar;
            GetComponentInChildren<TextMeshProUGUI>().font = ouijaFontAsset;
            GetComponentInChildren<TextMeshProUGUI>().text = humanChar.ToString();
        }

        public void OnButtonClicked()
        {
            OnOuijaButtonClicked.Invoke(character);
        }
    }
}