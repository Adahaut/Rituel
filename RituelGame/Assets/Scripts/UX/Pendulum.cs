using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    
    [SerializeField] private Transform bigClockHand;
    [SerializeField] private Transform smallClockHand;
    [SerializeField] private Transform pendulumBalance;
    [SerializeField] private AudioManager audioManager;


    private float rotationToApply = 15f;
    private float maxRotation = 14.5f;
    private float delayToMoveHandClock = 0.5f;
    private float currentBigClockRotation = 90;
    private float currentSmallClockRotation = 90;

    private void Start()
    {
        ActivatePendulumRotation();
    }

    private IEnumerator MoveHandClock()
    {
        yield return new WaitForSeconds(delayToMoveHandClock);
        Quaternion targetRotation = Quaternion.Euler(0, 0, currentBigClockRotation -= 360 / 60);
        bigClockHand.rotation = targetRotation;
        if ((int)bigClockHand.localEulerAngles.z == 90)
        {
            smallClockHand.rotation = Quaternion.Euler(0,0, currentSmallClockRotation -= 360/12);
            audioManager.PlayOverlap("Pendulum");
        }
        audioManager.PlayOverlap("tickclock");
    }

    private void ActivatePendulumRotation(bool left = false)
    {
        pendulumBalance.DORotateQuaternion(Quaternion.Euler(0, 0, left ? -rotationToApply : rotationToApply), 2f);
        StartCoroutine(MoveHandClock());
    }

    private void Update()
    {
        if (pendulumBalance.localEulerAngles.z > maxRotation - 0.1f && pendulumBalance.localEulerAngles.z < maxRotation + 0.1f)
        {
            ActivatePendulumRotation(true);
        }
        else if (pendulumBalance.localEulerAngles.z > 345f && pendulumBalance.localEulerAngles.z < 345.5f)
        {
            ActivatePendulumRotation(false);
        }
    }
}
