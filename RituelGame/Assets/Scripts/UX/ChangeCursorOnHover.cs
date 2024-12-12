using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Enigmas;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ChangeCursorOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Texture2D cursorTexture;
    Vector2 hotSpot = Vector2.zero;

    public bool _isCheckingBool;
    public MonoBehaviour _objectToCheck;
    public string _boolToCheck;
    public bool _shouldBeTrue = true;
    
    private void Start()
    {
        cursorTexture = Resources.Load<Texture2D>("clicker");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isCheckingBool)
        {
            FieldInfo field = _objectToCheck.GetType().GetField(_boolToCheck);
            if (field == null)
            {
                Debug.LogError("field not found");
                return;
            }

            bool fieldValue = (bool)field.GetValue(_objectToCheck);
            if ((fieldValue && !_shouldBeTrue) || (!fieldValue && _shouldBeTrue))
            {
                return;
            }
        }
        ActivateCursor();
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