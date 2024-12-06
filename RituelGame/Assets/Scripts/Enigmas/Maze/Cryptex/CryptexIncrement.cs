using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CryptexIncrement : MonoBehaviour
{
    List<CryptexStruct> cryptexStructs = new();
  
    public UnityEvent<List<CryptexStruct>> onCryptexStructsFull;
    public UnityEvent<CryptexStruct, int> onCryptextChanged;
    
    public void CheckIfFull(CryptexStruct cryptexStruct)
    {
        cryptexStructs.Add(cryptexStruct);

        if (cryptexStructs.Count == 5)
        {
            onCryptexStructsFull.Invoke(cryptexStructs);
        }
    }

    public void IncrementingValue(CryptexStruct cryptexStruct, int cryptexStructPos)
    {
        if (cryptexStruct.valueIndex == cryptexStruct.values.Count - 1)
        {
            cryptexStruct.valueIndex = 0;
            onCryptextChanged.Invoke(cryptexStruct, cryptexStructPos);
            return;
        }
        
        cryptexStruct.valueIndex++;
        onCryptextChanged.Invoke(cryptexStruct, cryptexStructPos);
    }
    
    public void DecrementingValue(CryptexStruct cryptexStruct, int cryptexStructPos)
    {
        if (cryptexStruct.valueIndex == 0)
        {
            cryptexStruct.valueIndex = cryptexStruct.values.Count - 1;
            onCryptextChanged.Invoke(cryptexStruct, cryptexStructPos);
            return;
        }
        
        cryptexStruct.valueIndex--;
        onCryptextChanged.Invoke(cryptexStruct, cryptexStructPos);
    }
}
