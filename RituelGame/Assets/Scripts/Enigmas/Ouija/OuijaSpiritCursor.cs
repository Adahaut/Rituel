using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Enigmas.Ouija;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OuijaSpiritCursor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, 
    IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private new Transform transform;
    [SerializeField] private Transform startPositionTransform;

    [SerializeField] private Image cursorImage;

    [SerializeField] private float holdScale = 1.25f;
    [SerializeField] private float droppedScale = 1f;
    [SerializeField] private float scaleDuration = 0.2f;

    public Action<OuijaCharacter> OnOuijaCharacterSelectedEvent;
    
    private TweenerCore<Vector3, Vector3, VectorOptions> moveToCursorTween;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        transform.position = startPositionTransform.position;
        transform.localScale = Vector3.one * droppedScale;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOKill();
        moveToCursorTween = transform.DOMove(GetMousePosition(), 0.2f).SetEase(Ease.OutQuint);
        transform.DOScale(Vector3.one * holdScale, scaleDuration);
        cursorImage.raycastTarget = false;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOKill();
        transform.DOScale(Vector3.one * droppedScale, scaleDuration);
        DetectLetter(eventData);
        cursorImage.raycastTarget = true;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        moveToCursorTween.Kill();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePosition = GetMousePosition();
        transform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    private void DetectLetter(PointerEventData eventData)
    {
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        RaycastResult raycastResult = raycastResults[0];
        
        GameObject resultGameObject = raycastResult.gameObject;
        OuijaCharacter ouijaCharacter = resultGameObject.GetComponentInParent<OuijaCharacter>();
        if (ouijaCharacter)
        {
            OnOuijaCharacterSelectedEvent.Invoke(ouijaCharacter);
        }
    }

    private static Vector2 GetMousePosition()
    {
        Camera camera = Camera.main;
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }
}
