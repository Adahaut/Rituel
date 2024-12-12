using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPendulum : MonoBehaviour
{
    [SerializeField] private Timer finalTimer;

    [SerializeField] private FinalClock finalClock;

    private void Update()
    {
        if (!finalClock)
        {
            return;
        }
        
        UpdatePendulum(finalTimer._timer);
    }

    private void UpdatePendulum(float time)
    {
        finalClock.UpdateClock(time);
    }
}
