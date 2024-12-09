using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Enigmas.Ouija
{
    public class OuijaCharacter : MonoBehaviour
    {
        [field:SerializeField] public TextMeshProUGUI _textMeshPro { get; private set; }
        public RectTransform _rectTransform { get; private set; }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
    }
}