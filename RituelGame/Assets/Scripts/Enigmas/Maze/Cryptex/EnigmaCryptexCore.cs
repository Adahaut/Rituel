using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmaCryptexCore : MonoBehaviour, AllInterafce.IEnigmaCore
{
    public EnigmaData _cryptexData;

    public LinkCore linkCore;

    public List<char> values = new();

    public string _answer;
    private string guess = "";

    public void CheckingIfStringIsCorrect(int value)
    {
        guess += values[value].ToString();

        if (guess.Length == 5)
        {
            if (guess == _answer)
            {
                Win();
            }
            else
            {
                Lose();
                guess = "";
            }
        }
    }

    public void Win()
    {
        linkCore.AddLink(_cryptexData.LinkToAddIfSuccess);
        _cryptexData.GetReward();
    }
    
    public void Lose()
    {
        linkCore.RemoveLink(_cryptexData.LinkToRemoveIfFail);
    }

    [field:SerializeField]
    public EnigmaType _enigmaType { get; set; }
    [field:SerializeField]
    public GameObject _unlockButtonThisEnigma { get; set; }
    public void UnlockNextEnigme()
    {
        if (_unlockButtonThisEnigma)
        {
            _unlockButtonThisEnigma.SetActive(true);   
        }
    }
}
