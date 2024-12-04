using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject candle1;
    [SerializeField] private GameObject candle2;
    [SerializeField] private GameObject candle3;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject timeScript;
    [SerializeField] private GameObject timeText;
    
    public TextMeshProUGUI _timerText;

    private float timer = 60.0f;
    public float _timerCounter = 0;

    private int humanCandleNumber = 0;
    private int spiritCandleNumber = 0;

    public void CandleAdd(int i)
    {
        if ((_timerCounter >= 10) && (_timerCounter <= 20) && i == 3)
        {
            spiritCandleNumber++; 
            candle1.SetActive(false);
        }
        else if ((_timerCounter >= 30) && (_timerCounter <= 40) && i == 4)
        {
            spiritCandleNumber++;
            candle2.SetActive(false);
        }
        else if ((_timerCounter >= 50) && (_timerCounter <= 60) && i == 5)
        {
            spiritCandleNumber++;
            candle3.SetActive(false);
        }
        else if ((_timerCounter >= 20) && (_timerCounter <= 30) && i == 1)
        {
            humanCandleNumber++;
            candle1.SetActive(false);
        }
        else if ((_timerCounter >= 40) && (_timerCounter <= 50) && i == 2)
        {
            humanCandleNumber++;
            candle2.SetActive(false);
        }
        else
            Loose();
    }
    
    void Update()
    {
        _timerCounter += Time.deltaTime;
        if (((_timerCounter >= timer) && (spiritCandleNumber >= 3)) || ((_timerCounter >= timer) && (humanCandleNumber >= 2)))
        {
            Debug.Log("Win");
        }
        else if (_timerCounter >= timer)
        {
            Loose();
        }
        _timerText.text = _timerCounter.ToString();

    }

    void Loose()
    {
        humanCandleNumber = 0;
        spiritCandleNumber = 0;
        //perte de liaison
        _timerCounter = 0;
        candle1.SetActive(false);
        candle2.SetActive(false);
        candle3.SetActive(false);
        startButton.SetActive(true);
        timeScript.SetActive(false);
        timeText.SetActive(false);
    }
}