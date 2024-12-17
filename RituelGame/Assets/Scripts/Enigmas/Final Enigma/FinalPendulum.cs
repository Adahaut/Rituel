using DG.Tweening;
using UnityEngine;

public class FinalPendulum : MonoBehaviour
{
    [SerializeField] private Timer finalTimer;

    [SerializeField] private FinalClock finalClock;
    [SerializeField] private Transform pendulumBalance;
    
    private float rotationToApply = 15f;
    private float maxRotation = 14.5f;

    private void Start()
    {
        ActivatePendulumRotation();
        for (int i = 0; i < finalTimer._values.Count; i++)
        {
            finalTimer._timeClocks[i].UpdateClock(finalTimer._values[i]);
        }
    }
    
    public void ActivatePendulumRotation(bool left = false)
    {
        pendulumBalance.DORotateQuaternion(Quaternion.Euler(0, 0, left ? -rotationToApply : rotationToApply), 2f);
        StartCoroutine(finalClock.MoveHandClock());
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
