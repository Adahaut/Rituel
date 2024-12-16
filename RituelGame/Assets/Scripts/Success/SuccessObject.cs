using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuccessObject : MonoBehaviour
{
    public SuccessData _successData;

    public TextMeshProUGUI _textSuccessName;
    public TextMeshProUGUI _textSuccessDescription;
    public Image _imageSuccess;
    public Image _background;

    public float _animeDuration;
    
    void Start()
    {
        _textSuccessName.text = _successData._successName;
        _textSuccessDescription.text = _successData._description;
        _imageSuccess.sprite = _successData._succesImage;
        transform.localPosition = Vector3.zero;
        
        Initialize();
    }

    public void Initialize()
    {
        if (!_successData.GetUnlock())
        {
            _textSuccessName.color = new Color(_textSuccessName.color.r, _textSuccessName.color.g, _textSuccessName.color.b, 0.5f);
            _textSuccessDescription.color = new Color(_textSuccessDescription.color.r, _textSuccessDescription.color.g, _textSuccessDescription.color.b, 0.5f);
            _imageSuccess.color = new Color(_imageSuccess.color.r, _imageSuccess.color.g, _imageSuccess.color.b, 0.5f);   
            _background.color = new Color(_background.color.r, _background.color.g, _background.color.b, 0.5f);   
        }
        else
        {
            _textSuccessName.color = new Color(_textSuccessName.color.r, _textSuccessName.color.g, _textSuccessName.color.b, 1f);
            _textSuccessDescription.color = new Color(_textSuccessDescription.color.r, _textSuccessDescription.color.g, _textSuccessDescription.color.b, 1f);
            _imageSuccess.color = new Color(_imageSuccess.color.r, _imageSuccess.color.g, _imageSuccess.color.b, 1f);   
            _background.color = new Color(_background.color.r, _background.color.g, _background.color.b, 1f);   
        }
    }

    public void Unlock()
    {
        _successData.UnlockSuccess();
        Initialize();
        StartCoroutine(UnlockAnim(_animeDuration));
    }

    private IEnumerator UnlockAnim(float duration)
    {
        transform.DOLocalMove(new Vector3(0f, 200f, 0f) + transform.localPosition, duration);
        yield return new WaitForSeconds(duration * 2);
        _textSuccessName.DOFade(0, duration);
        _textSuccessDescription.DOFade(0, duration);
        _imageSuccess.DOFade(0, duration);
        _background.DOFade(0, duration);
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
