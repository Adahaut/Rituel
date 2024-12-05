using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnigmaData", menuName = "Enigmas/EnigmaData")]
public class EnigmaData : ScriptableObject
{
    public string enigmaName;
    public string description;
    public GameObject reward;
    public string success;
    public int LinkToAddIfSuccess;
    public int LinkToRemoveIfFail;

}
