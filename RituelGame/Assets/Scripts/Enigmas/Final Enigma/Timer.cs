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
    [SerializeField] private List<FinalClock> timeClocks;
    [SerializeField] private List<int> values;

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


    private void Start()
    {
        for (int i = 0; i < values.Count; i++)
        {
            timeClocks[i].UpdateClock(values[i]);
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
        OnEnigmaReset();
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