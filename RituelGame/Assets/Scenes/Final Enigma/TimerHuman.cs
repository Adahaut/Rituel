using System;
using TMPro;
using UnityEngine;

public class TimerHuman : MonoBehaviour
{
    
    [SerializeField] private GameObject candle1;
    [SerializeField] private GameObject candle2;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject timeScript;
    [SerializeField] private GameObject timeText;

    public TextMeshProUGUI timerText;
    
    private float timer = 60.0f;
    public float _timerCounter = 0;

    private int candleNumber = 0;

    public void CandleAdd1()
    {
        if ((_timerCounter >= 20) && (_timerCounter <= 30))
        {
            candleNumber++;
            candle1.SetActive(false);
        }
        else
        {
            Loose();
        }
    }
    
    public void CandleAdd2()
    {
        if ((_timerCounter >= 40) && (_timerCounter <= 50))
        {
            candleNumber++;
            candle2.SetActive(false);
        }
        else
        {
            Loose();
        }
    }

    void Update()
    {
        
        _timerCounter += Time.deltaTime;
        if ((_timerCounter >= timer) && (candleNumber >= 2))
        {
            Debug.Log("Win");
        }
        else if ((_timerCounter >= timer) && (candleNumber < 2))
        {
            Loose();
        }
        
        timerText.text = _timerCounter.ToString();
    }

    void Loose()
    {
        candleNumber = 0;
        //perte de liaison
        _timerCounter = 0;
        candle1.SetActive(false);
        candle2.SetActive(false);
        startButton.SetActive(true);
        timeScript.SetActive(false);
        timeText.SetActive(false);
    }
}
