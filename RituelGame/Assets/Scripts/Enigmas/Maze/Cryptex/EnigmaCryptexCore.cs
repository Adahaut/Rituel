using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmaCryptexCore : MonoBehaviour
{
    public EnigmaData cryptexData;

    public CryptexStringChecker stringChecker;
    
    public void Win()
    {
        Debug.Log("Win");
    }

    public void Lose()
    {
        Debug.Log("Lose");
        stringChecker.isGood = true;
    }
}
