using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeScaleOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private new Transform transform;
    private Vector3 originalScale;
    [SerializeField] private float addedScaleOnHover = 0.2f;
    [SerializeField] private float timeToScale = 0.45f;
    [SerializeField] private Ease easeType = Ease.OutQuint;
    
    private void Awake()
    {
        transform = GetComponent<Transform>();
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ScaleEnter();
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        ScaleExit();
    }
    
    private void ScaleEnter()
    {
        transform.DOScale((Vector3.one * addedScaleOnHover) + originalScale, timeToScale).SetEase(easeType);
    }
    
    private void ScaleExit()
    {
        transform.DOScale(originalScale, timeToScale).SetEase(easeType);
    }
}
