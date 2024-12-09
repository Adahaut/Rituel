using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject timeScript;
    [SerializeField] private GameObject timeText;
    [SerializeField] private GameObject candle;
    [SerializeField] private List<TextMeshProUGUI> texts;
    [SerializeField] private List<int> values;
    
    
    public TextMeshProUGUI _timerText;

    [SerializeField] private float acceptanceInterval;
    
    private float maxTime = 60.0f;
    public float _timer = 0;

    private int currentCandleNumber = 0;
    public int _finalCandleNumber;

    [SerializeField] private LinkCore linkCore;
    [SerializeField] private EnigmaData enigmaData;

    private void Start()
    {
        for (int i = 0; i < values.Count; i++)
        {
            texts[i].text = values[i].ToString();
        }
    }

    public void CheckClickTiming(float clickTime)
    {
        if (Mathf.Abs(_timer-clickTime) <= acceptanceInterval)
        {
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);
            currentCandleNumber++;
        }
        else
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
            Loose();
        }
    }

    public void ResetTimer()
    {
        _timer = 0;
    }
    
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= maxTime)
        {
            if (currentCandleNumber >= _finalCandleNumber)
            {
            }
            else
                Loose();
        }
        _timerText.text = _timer.ToString();

    }

    void Loose()
    {
        currentCandleNumber = 0;
        //perte de liaison
        _timer = 0;
        startButton.SetActive(true);
        timeScript.SetActive(false);
        timeText.SetActive(false);
        candle.SetActive(false);
    }
}