using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalClock : MonoBehaviour
{
    [SerializeField] private float startTime;
    
    [SerializeField] private Transform minutesClockHand;
    [SerializeField] private Transform hoursClockHand;

    private void Awake()
    {
        UpdateClock(startTime);
    }

    public void UpdateClock(float time)
    {
        float minutesAngle = Mathf.Lerp(0, -360, (time % 60) / 60f);
        float hoursAngle = Mathf.Lerp(0, -360, (time % 3600) / 3600f);

        minutesClockHand.localRotation = Quaternion.Euler(0, 0, minutesAngle);
        hoursClockHand.localRotation = Quaternion.Euler(0, 0, hoursAngle);
    }
}
