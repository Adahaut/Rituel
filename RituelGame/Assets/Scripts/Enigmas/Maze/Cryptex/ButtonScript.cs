using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public EnigmaCryptexCore _enigmaCryptexCore;

    public List<CryptexCircles> _circles = new();

    public void GivingToCore()
    {
        for (int i = 0; i < _circles.Count; i++)
        {
            _enigmaCryptexCore.CheckingIfStringIsCorrect(_circles[i].SendingValues());
        }
    }
}
