using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class IntroductionText : MonoBehaviour
{
     public GameObject _canvasIntro;
     public TextMeshProUGUI _textIntro;
     public float _fadeDuration;
     public float _fadeInMultiplier;
     public float _staticTextMultiplier;

     private void Start()
     {
          StartCoroutine(PerformFade(_fadeDuration));
     }

     private IEnumerator PerformFade(float duration)
     {
          _textIntro.DOFade(1, duration * _fadeInMultiplier);
          yield return new WaitForSeconds(_staticTextMultiplier);
          _textIntro.DOFade(0, duration);
          yield return new WaitForSeconds(duration);
          _canvasIntro.SetActive(false);
     }
}
