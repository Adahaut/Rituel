using System;
using System.Collections;
using System.Collections.Generic;
using Enigmas;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorChangedOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Texture2D cursorTexture;
    Vector2 hotSpot = Vector2.zero;
    private void Start()
    {
        cursorTexture = Resources.Load<Texture2D>("clicker");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!eventData.pointerEnter.GetComponent<EnigmaButton>()._enigmaFinish)
        {
            ActivateCursor();   
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DesactivateCursor();
    }

    public void ActivateCursor()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);
    }
    
    public void DesactivateCursor()
    {
        Cursor.SetCursor(null, hotSpot, CursorMode.ForceSoftware);
    }
}
