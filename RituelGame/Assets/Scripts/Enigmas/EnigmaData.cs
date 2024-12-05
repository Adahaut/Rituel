using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnigmaData", menuName = "Enigmas/EnigmaData")]
public class EnigmaData : ScriptableObject
{
    [SerializeField] private string enigmaName;
    public string EnigmaName => enigmaName;
    [SerializeField] private string description;
    public string Description => description;
    [SerializeField] private GameObject reward;
    [SerializeField] private string success;
    public string Success => success;
    [SerializeField] private int linkToAddIfSuccess;
    public int LinkToAddIfSuccess => linkToAddIfSuccess;
    [SerializeField] private int linkToRemoveIfFail;
    public int LinkToRemoveIfFail => linkToRemoveIfFail;

    public void GetReward()
    {
        if (reward) reward.SetActive(true);
    }
}
