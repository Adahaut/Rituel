using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FinalClock : MonoBehaviour
{
    [SerializeField] private float startTime;

    [SerializeField] private Transform minutesClockHand;
    [SerializeField] private Transform hoursClockHand;
    
    [SerializeField] private AudioManager audioManager;
    
    private float delayToMoveHandClock = 0.5f;
    public float _currentBigClockRotation;
    public float _currentSmallClockRotation;
    private float _timer = 0;
    private float minutesClockMakeOneTurn = 60;

    public void UpdateClock(float time)
    {
        float minutesAngle = Mathf.Lerp(0, -360, (time % 60) / 60f);
        float hoursAngle = Mathf.Lerp(0, -360, (time % 3600) / 3600f);

        minutesClockHand.localRotation = Quaternion.Euler(0, 0, minutesAngle);
        hoursClockHand.localRotation = Quaternion.Euler(0, 0, hoursAngle);
    }
    
    public IEnumerator MoveHandClock()
    {
        yield return new WaitForSeconds(delayToMoveHandClock);

        audioManager.PlayOverlap("tickclock");
    }
}
