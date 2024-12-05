using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerEvents : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public UnityEvent OnPointerEnterEvent;
    public UnityEvent OnPointerClickEvent;
    public UnityEvent OnPointerExitEvent;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEnterEvent.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerClickEvent.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerExitEvent.Invoke();
    }
}
