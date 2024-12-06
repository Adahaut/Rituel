using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexButton : MonoBehaviour
{
    public EnigmaCryptexCore _cryptexCore;
    
    public List<CryptexCircles> _cryptexCircles = new();

    public void GivingToCore()
    {
        for (int i = 0; i < _cryptexCircles.Count; i++)
        {
            _cryptexCore.CheckIfStringIsCorrect(_cryptexCircles[i].SendingValues());
        }
    }
}
