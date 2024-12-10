using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    
    [SerializeField] private Transform bigClockHand;
    [SerializeField] private Transform smallClockHand;
    [SerializeField] private Transform pendulumBalance;
    [SerializeField] private AudioManager audioManager;


    private float rotationToApply = 15f;
    private float maxRotation = 14.5f;

    private void Start()
    {
        ActivatePendulumRotation();
    }
    
    private void 

    private void ActivatePendulumRotation(bool left = false)
    {
        pendulumBalance.DORotateQuaternion(Quaternion.Euler(0, 0, left ? -rotationToApply : rotationToApply), 2f);
        audioManager.PlayDelay("tickclock", 0.5f);
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
