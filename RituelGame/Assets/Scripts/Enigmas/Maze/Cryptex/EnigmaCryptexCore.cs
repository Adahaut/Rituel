using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmaCryptexCore : MonoBehaviour
{
    public EnigmaData _cryptexData;
    public CryptexDisplay _cryptexDisplay;
    
    public GameObject _maze;
    public GameObject _cryptex;
    
    public List<char> values = new();

    public string _answer;
    private string guess = "";

    private void Start()
    {
        _cryptexDisplay.SettingInList();
        _cryptexDisplay.DisplayingChars(values);
    }

    public void CheckIfStringIsCorrect(int value)
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
            }
        }
    }

    private void Win()
    {
        Debug.Log("Win");
        _cryptex.SetActive(false);
        _maze.SetActive(true);
    }

    private void Lose()
    {
        Debug.Log("Lose");
        guess = "";
    }
}
