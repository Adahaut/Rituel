using System;
using UnityEngine;
using UnityEngine.UI;

namespace Enigmas.Ouija
{
    public class OuijaButton : MonoBehaviour
    {
        private char character;
        public Action<char> OnOuijaButtonClicked;

        public void SetOuijaSprite(char humanChar,Sprite ouijaSprite)
        {
            character = humanChar;
            GetComponent<Image>().sprite = ouijaSprite;
        }

        public void OnButtonClicked()
        {
            OnOuijaButtonClicked.Invoke(character);
        }
    }
}