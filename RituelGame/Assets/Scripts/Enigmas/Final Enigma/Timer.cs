using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject victoryGameObject;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject timeScript;
    [SerializeField] private GameObject timeText;
    [SerializeField] private GameObject candle;
    [SerializeField] private GameObject backButton;
    public List<FinalClock> _timeClocks;
    public List<int> _values;
    [SerializeField] private List<AutoCandle> autoCandleOrdered;

    [SerializeField] private GameObject _frontPanel;

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
        for (int i = 0; i < _values.Count; i++)
        {
            _timeClocks[i].UpdateClock(_values[i]);
        }
        ResetTimer();
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
        linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail + addedLink);
        startButton.SetActive(true);
        currentCandleNumber = 0;
        addedLink = 0;
        autoIndex = 0;
        foreach (var autoCandle in autoCandleOrdered)
        {
            autoCandle.UnLightCandle();
        }
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

        PlayerPrefs.SetInt("CinematicDone", 0);
        SceneManager.LoadScene("FinalCinematic");
        
        Restart();
    }

    void Restart()
    {
        _timer = 0;
        timeScript.SetActive(false);
        backButton.SetActive(true);
        _frontPanel.SetActive(true);
        audioManager.StopSound("CracklingCandle");
        OnEnigmaReset?.Invoke();
    }
}