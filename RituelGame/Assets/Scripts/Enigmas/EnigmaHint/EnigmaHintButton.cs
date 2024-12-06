using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Enigmas.EnigmaHint
{
    public class EnigmaHintButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private EnigmaData enigmaData;
        [SerializeField] private WorldType currentWorldType;
        
        public static Action<EnigmaData, WorldType> OnHintButtonClicked;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnHintButtonClicked.Invoke(enigmaData, currentWorldType);
        }
    }
}