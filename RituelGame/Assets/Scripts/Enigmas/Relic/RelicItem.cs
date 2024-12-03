using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RelicItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public int _symboleInInspector;
    public int _symbole { get; private set;} 
    
    public Sprite _sprite;
    public RelicController _relicController;

    private void Start()
    {
        _symbole = _symboleInInspector;
        GetComponent<SpriteRenderer>().sprite = _sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _relicController.CheckRelicSymbole(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
    }
}
