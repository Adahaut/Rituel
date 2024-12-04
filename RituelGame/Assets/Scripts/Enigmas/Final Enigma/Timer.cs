using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject timeScript;
    [SerializeField] private GameObject timeText;
    [SerializeField] private GameObject candle;
    
    public TextMeshProUGUI _timerText;

    [SerializeField] private float acceptanceInterval;
    
    private float timer = 60.0f;
    public float _timerCounter = 0;

    private int currentCandleNumber = 0;
    public int _finalCandleNumber;

    public void CheckClickTiming(float clickTime)
    {
        if (Mathf.Abs(_timerCounter-clickTime) <= acceptanceInterval)
        {
            currentCandleNumber++;
        }
        else
            Loose();
    }
    
    void Update()
    {
        _timerCounter += Time.deltaTime;
        if (((_timerCounter >= timer) && (currentCandleNumber >= _finalCandleNumber)))
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
        currentCandleNumber = 0;
        //perte de liaison
        _timerCounter = 0;
        startButton.SetActive(true);
        timeScript.SetActive(false);
        timeText.SetActive(false);
        candle.SetActive(false);
    }
}