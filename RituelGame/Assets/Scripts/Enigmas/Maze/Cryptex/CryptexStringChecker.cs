using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexStringChecker : MonoBehaviour
{
    public EnigmaCryptexCore enigmaCryptexCore;
    
    List<CryptexStruct> cryptexStructs = new();
    
    public List<char> cryptexCodeWanted = new();

    public bool isGood;

    private void Start()
    {
        isGood = true;
    }

    public void CheckIfFull(CryptexStruct cryptexStruct)
    {
        cryptexStructs.Add(cryptexStruct);
    }

    public void ChangingStructList(CryptexStruct cryptexStruct, int index)
    {
        cryptexStructs[index] = cryptexStruct;
    }

    public void CheckCryptexString()
    {
        for (int i = 0; i < cryptexStructs.Count; i++)
        {
            if (isGood)
            {
                if (cryptexCodeWanted[i] != cryptexStructs[i].values[cryptexStructs[i].valueIndex])
                {
                    enigmaCryptexCore.Lose();
                    isGood = false;
                    return;
                }
                
                if(i == cryptexStructs.Count - 1)
                    enigmaCryptexCore.Win();
            }
        }
    }
}