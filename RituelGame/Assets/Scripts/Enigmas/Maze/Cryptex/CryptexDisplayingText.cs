using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CryptexDisplayingText : MonoBehaviour
{
    public CryptexValue cryptexValue;
    
    public List<TextMeshProUGUI> texts = new();

    private void Start()
    {
        for (int i = 0; i < cryptexValue.circlesValues.Count; i++)
        {
            texts[i].text = cryptexValue.circlesValues[i].ToString();
        }
    }
}
