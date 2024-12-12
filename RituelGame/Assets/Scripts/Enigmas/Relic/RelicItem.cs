using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RelicItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int _symboleInInspector;
    public int _symbole { get; private set;} 
    
    public Sprite _sprite;
    public RelicController _relicController;

    public Texture2D _hammerSprite;
    private void Start()
    {
        _symbole = _symboleInInspector;
        GetComponent<Image>().sprite = _sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _relicController.CheckRelicSymbole(this);
        
        Destroy(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(_hammerSprite, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }
}
