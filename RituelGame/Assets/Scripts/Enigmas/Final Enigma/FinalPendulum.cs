using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPendulum : MonoBehaviour
{
    [SerializeField] private Timer finalTimer;
    
    [SerializeField] private Transform minutesClockHand;
    [SerializeField] private Transform hoursClockHand;

    private void Update()
    {
        if (!minutesClockHand || !hoursClockHand)
        {
            return;
        }
        
        UpdatePendulum(finalTimer._timer);
    }

    public void UpdatePendulum(float time)
    {
        float minutesAngle = Mathf.Lerp(0, -360, (time % 60) / 60f);
        float hoursAngle = Mathf.Lerp(0, -360, (time % 3600) / 3600f);

        minutesClockHand.localRotation = Quaternion.Euler(0, 0, minutesAngle);
        hoursClockHand.localRotation = Quaternion.Euler(0, 0, hoursAngle);
    }
}
