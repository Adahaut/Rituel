using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject timeScript;
    [SerializeField] private GameObject timeText;
    [SerializeField] private GameObject candle;
    [SerializeField] private GameObject backButton;
    public List<FinalClock> _timeClocks;
    public List<int> _values;
    [SerializeField] private List<AutoCandle> autoCandleOrdered;

    private int autoIndex = 0;
    
    public WorldType _worldType;
    
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

    public Action OnEnigmaReset;
    
    private float minutesClockMakeOneTurn = 60;
    
    private void Start()
    {
    }

    public void CheckClickTiming(float clickTime)
    {
        if (Mathf.Abs(_timer - clickTime) <= acceptanceInterval) 
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
        OnEnigmaReset();
    }
    
    void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= minutesClockMakeOneTurn)
        {
            audioManager.PlayOverlap("Pendulum");
            minutesClockMakeOneTurn += 60;
        }
        
        if (_timer >= maxTime)
        {
            if (currentCandleNumber >= _finalCandleNumber)
            {
                Win();
            }
            else
                Loose();
        }

        if (_values.Count > autoIndex)
        {
            if (Mathf.Abs(_timer - _values[autoIndex]) <= acceptanceInterval) 
            {
                autoCandleOrdered[autoIndex].LightCandle();
                autoIndex++;
            }
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
        SuccessManager successManager = FindObjectOfType<SuccessManager>();

        if (_worldType == WorldType.Spirit)
        {
            successManager.SpawnSuccess(SuccesType.DimensionTraveler);
        
            if (linkCore.linkCount <= 10)
            {
                successManager.SpawnSuccess(SuccesType.TheFallen);
            }
            else if (linkCore.linkCount == 100)
            {
                successManager.SpawnSuccess(SuccesType.SpiritMaster);
            }
        }
        else if (_worldType == WorldType.Human)
        {
            successManager.SpawnSuccess(SuccesType.NeedAnExorcist);
        
            if (linkCore.linkCount <= 10)
            {
                successManager.SpawnSuccess(SuccesType.NoReviveHere);
            }
            else if (linkCore.linkCount == 100)
            {
                successManager.SpawnSuccess(SuccesType.HumanMaster);
            }
        }
        
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
        OnEnigmaReset?.Invoke();
    }
}