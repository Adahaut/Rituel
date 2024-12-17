using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimOnButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image _image;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.DOFade(1, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.GetComponent<Image>().DOFade(0, 0.3f);
    }

    public void FadingOut()
    {
        _image.GetComponent<Image>().DOFade(0, 0.3f);
    }
}