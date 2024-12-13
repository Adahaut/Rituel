using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private Light2D humanLight;
    [SerializeField] private Light2D spiritLight;

    private Vector2 mousePos;

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x < 0)
        {
            spiritLight.intensity = 0;
            if (mousePos.x < -5)
            {
                humanLight.intensity = 1;
            }
            else
            {
                humanLight.intensity = 1f / (1f - Mathf.Abs(mousePos.x) + 5);
            }
        }
        else
        {
            humanLight.intensity = 0;
            if (mousePos.x > 5)
            {
                spiritLight.intensity = 1;
            }
            else
            {
                spiritLight.intensity = 1f / (1f - Mathf.Abs(mousePos.x) + 5);
            }
        }
    }
}
