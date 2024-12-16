using System.Reflection;
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
    
    public bool _isCheckingBool;
    public MonoBehaviour _objectToCheck;
    public string _boolToCheck;
    public bool _shouldBeTrue = true;
    
    private void Awake()
    {
        transform = GetComponent<Transform>();
        originalScale = transform.localScale;
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
