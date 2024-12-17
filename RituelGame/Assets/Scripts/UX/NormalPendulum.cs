using DG.Tweening;
using UnityEngine;

public class NormalPendulum : MonoBehaviour
{
    [SerializeField] private Timer finalTimer;
    [SerializeField] private Clock clock;
    [SerializeField] private Transform pendulumBalance;
    
    private float rotationToApply = 15f;
    private float maxRotation = 14.5f;

    private void Start()
    {
        ActivatePendulumRotation();
    }
    
    public void ActivatePendulumRotation(bool left = false)
    {
        pendulumBalance.DORotateQuaternion(Quaternion.Euler(0, 0, left ? -rotationToApply : rotationToApply), 2f);
        StartCoroutine(clock.MoveHandClock());
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
        
        if (!clock)
        {
            return;
        }
        UpdatePendulum(finalTimer._timer);
    }

    private void UpdatePendulum(float time)
    {
        clock.UpdateClock(time);
    }
}