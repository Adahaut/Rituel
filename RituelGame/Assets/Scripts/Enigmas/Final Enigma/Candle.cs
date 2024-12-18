using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Candle : MonoBehaviour
{
    [SerializeField] private Timer finalTimer;
    
    [SerializeField] private Sprite unlitCandleSprite;
    [SerializeField] private Sprite litCandleSprite;
    
    public float _requiredTime;

    public bool _isLit;
    
    private Image candleImage;
    
    private void Awake()
    {
        candleImage = GetComponent<Image>();
        finalTimer.OnEnigmaReset += ResetCandle;
        ResetCandle();
    }

    public void OnCandleClicked()
    {
        if (_isLit)
        {
            return;
        }

        _isLit = true;
        candleImage.sprite = litCandleSprite;
        finalTimer.CheckClickTiming(_requiredTime);
        gameObject.GetComponent<AnimeCandle>().StartAnime();
    }
    
    public void ResetCandle()
    {
        _isLit = false;
        gameObject.GetComponent<AnimeCandle>().StopAnime();
        candleImage.sprite = unlitCandleSprite;
    }
}
