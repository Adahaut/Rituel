using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject timeScript;
    [SerializeField] private GameObject timeText;
    [SerializeField] private GameObject candle;
    
    public TextMeshProUGUI _timerText;

    [SerializeField] private float maxTime;
    [SerializeField] private float acceptanceInterval;
    
    public float _timer = 0;

    private int currentCandleNumber = 0;
    public int _finalCandleNumber;

    public void CheckClickTiming(float clickTime)
    {
        if (Mathf.Abs(_timer-clickTime) <= acceptanceInterval)
        {
            currentCandleNumber++;
        }
        else
            Loose();
    }
    
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= maxTime)
        {
            if (currentCandleNumber >= _finalCandleNumber)
            {
                Win();
            }
            else
                Loose();
        }
        _timerText.text = _timer.ToString();

    }
    
    void Win()
    {
        //gain de liaison
        Restart();
    }
    
    void Loose()
    {
        currentCandleNumber = 0;
        //perte de liaison
        startButton.SetActive(true);
        Restart();
    }
    
    void Restart()
    {
        _timer = 0;
        timeScript.SetActive(false);
        timeText.SetActive(false);
        candle.SetActive(false);
    }
}