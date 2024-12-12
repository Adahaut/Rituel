using UnityEngine;

public class CandleMouse : MonoBehaviour
{
    private Vector3 lastMousePosition;
    private float volume = 0.7f;
    [SerializeField] private AudioManager audioManager;

    void Start()
    {
        audioManager.PlaySound("CracklingCandle");
    }

    void Update()
    {
        if (Input.mousePosition != lastMousePosition)
        {
            lastMousePosition=Input.mousePosition;
            volume = 0.5f;
        } else
            volume = 0.7f;
        audioManager.ChangeVolume("CracklingCandle" , volume);
    }
}
