using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CryptexDisplay : MonoBehaviour
{
    private List<List<TextMeshProUGUI>> texts = new();
    public List<TextMeshProUGUI> firstTextDisplay = new();
    public List<TextMeshProUGUI> secondTextDisplay = new();
    public List<TextMeshProUGUI> thirdTextDisplay = new();
    public List<TextMeshProUGUI> fourthTextDisplay = new();
    public List<TextMeshProUGUI> fifthTextDisplay = new();
    
    public UnityEvent OnDisplay;

    public void SettingInList()
    {
        texts.Add(firstTextDisplay);
        texts.Add(secondTextDisplay);
        texts.Add(thirdTextDisplay);
        texts.Add(fourthTextDisplay);
        texts.Add(fifthTextDisplay);
    }
    
    public void DisplayingChars(List<char> values)
    {
        for (int i = 0; i < texts.Count; i++)
        {
            for (int j = 0; j < values.Count; j++)
            {
                texts[i][j].text = values[j].ToString();
            }
        }
        
        OnDisplay.Invoke();
    }
}
