using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmaCryptexCore : MonoBehaviour
{
    public EnigmaData _cryptexData;

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
        Debug.Log("Win");
    }
    
    public void Lose()
    {
        Debug.Log("Lose");
    }
}
