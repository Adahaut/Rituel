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
    [SerializeField] private GameObject backButton;
    [SerializeField] private List<TextMeshProUGUI> texts;
    [SerializeField] private List<int> values;
    
    
    public TextMeshProUGUI _timerText;

    [SerializeField] private float maxTime; 
    [SerializeField] private float acceptanceInterval;
    
    public float _timer = 0;

    private int currentCandleNumber = 0;
    public int _finalCandleNumber;

    [SerializeField] private LinkCore linkCore;
    [SerializeField] private EnigmaData enigmaData;
    [SerializeField] private AudioManager audioManager;

    private int addedLink = 0;

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
            audioManager.PlayOverlap("LightACandle");
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);
            currentCandleNumber++;
            addedLink += enigmaData.LinkToAddIfSuccess;
        }
        else
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail + addedLink);
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
                Win();
            }
            else
                Loose();
        }
        _timerText.text = _timer.ToString();

    }

    void Loose()
    {
        currentCandleNumber = 0;
        addedLink = 0;
        //perte de liaison
        startButton.SetActive(true);
        Restart();
    }

    void Win()
    {
        //gain de liaison
        Restart();
    }

    void Restart()
    {
        _timer = 0;
        timeScript.SetActive(false);
        timeText.SetActive(false);
        candle.SetActive(false);
        backButton.SetActive(true);
        audioManager.StopSound("CracklingCandle");
    }
}