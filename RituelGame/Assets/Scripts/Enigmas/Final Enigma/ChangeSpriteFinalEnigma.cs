using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeSpriteFinalEnigma : MonoBehaviour, IPointerClickHandler
{
    public Sprite _candleOnSprite;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = _candleOnSprite;
        gameObject.GetComponent<Button>().interactable = false;
    }
}
