using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject timeScript;
    [SerializeField] private GameObject timeText;
    [SerializeField] private GameObject candle;
    
    public TextMeshProUGUI _timerText;

    [SerializeField] private float acceptanceInterval;
    
    private float maxTime = 60.0f;
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
                Debug.Log("Win");
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