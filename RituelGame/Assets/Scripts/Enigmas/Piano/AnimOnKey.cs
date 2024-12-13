using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimOnKey : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().DOColor(new Color(0.9f, 0.9f, 0.9f, 0.9f), 0.25f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().DOColor(new Color(1f, 1f, 1f, 1f), 0.25f);
    }
}
