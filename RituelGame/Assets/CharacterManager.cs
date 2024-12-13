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
            humanLight.intensity = 1;
            spiritLight.intensity = 0;
        }
        else
        {
            humanLight.intensity = 0;
            spiritLight.intensity = 1;
        }
    }
}
