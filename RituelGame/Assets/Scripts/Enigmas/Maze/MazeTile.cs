using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Enigmas.Maze
{
    public class MazeTile : MonoBehaviour, IPointerClickHandler
    {
        public Action<GameObject> OnTileClickedEvent;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnTileClickedEvent?.Invoke(gameObject);
        }
    }
}