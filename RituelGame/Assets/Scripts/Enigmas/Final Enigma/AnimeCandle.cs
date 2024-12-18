using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimeCandle : MonoBehaviour
{
    public Sprite _candleAnime1;
    public Sprite _candleAnime2;
    public Sprite _candleAnime3;
    private Image candleImage;

    private void Start()
    {
        candleImage = gameObject.GetComponent<Image>();
    }

    public void StartAnime()
    {
        StartCoroutine(AnimeCandleCoroutine(0.5f));
    }

    public void StopAnime()
    {
        StopAllCoroutines();
    }
    
    private IEnumerator AnimeCandleCoroutine(float duration)
    {
        candleImage.sprite = _candleAnime1;
        yield return new WaitForSeconds(duration);
        candleImage.sprite = _candleAnime2;
        yield return new WaitForSeconds(duration);
        candleImage.sprite = _candleAnime3;
        yield return new WaitForSeconds(duration);
        StartCoroutine(AnimeCandleCoroutine(duration));
    }
}
