using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class LinkAnimation : MonoBehaviour
{
    public GameObject _linkSlider;
    public TextMeshProUGUI _linkText;
    public Vector2 _linkScaleAnime;
    public float _timeOfAnimation = 0.2f;
    private Vector2 initScale;
    private Color initColor;
    public Color _loseColor;
    public Color _winColor;
    private LinkUI linkUI;

    private void Start()
    {
        linkUI = GetComponent<LinkUI>();
        initScale = _linkSlider.transform.localScale;
        initColor = Color.black;
        linkUI.UpdateLinkSlider();
    }

    public void StartLinkAnimation(bool isWin)
    {
        if (isWin)
            StartCoroutine(AnimateWinLink());
        else 
            StartCoroutine(AnimateLoseLink());
    }

    private IEnumerator AnimateLoseLink()
    {
        float duration = 0.5f;
        _linkSlider.transform.DOScale(_linkScaleAnime, duration);
        yield return new WaitForSeconds(duration);
        _linkText.DOColor(_loseColor, duration);
        linkUI.UpdateLinkSlider();
        yield return new WaitForSeconds(duration);
        _linkText.DOColor(initColor, duration);
        yield return new WaitForSeconds(duration);
        _linkSlider.transform.DOScale(initScale, duration);
    }
    
    private IEnumerator AnimateWinLink()
    {
        float duration = 0.5f;
        _linkSlider.transform.DOScale(_linkScaleAnime, duration);
        yield return new WaitForSeconds(duration);
        _linkText.DOColor(_winColor, duration);
        linkUI.UpdateLinkSlider();
        yield return new WaitForSeconds(duration);
        _linkText.DOColor(initColor, duration);
        yield return new WaitForSeconds(duration);
        _linkSlider.transform.DOScale(initScale, duration);
    }
}
