using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "EnigmaData", menuName = "Enigmas/EnigmaData")]
public class EnigmaData : ScriptableObject
{
    [SerializeField] private string enigmaName;
    public string EnigmaName => enigmaName;
    [SerializeField] private string description;
    public string Description => description;
    [SerializeField] private SerializedDictionary<WorldType, string> enigmaHint;
    public SerializedDictionary<WorldType, string> EnigmaHint => enigmaHint;
    [SerializeField] private GameObject reward;
    [SerializeField] private string success;
    public string Success => success;
    [SerializeField] private int linkToAddIfSuccess;
    public int LinkToAddIfSuccess => linkToAddIfSuccess;
    [SerializeField] private int linkToRemoveIfFail;
    public int LinkToRemoveIfFail => linkToRemoveIfFail;

    public EnigmaType _enigmaTypeToUnlock;
 
    public void GetReward()
    {
        MonoBehaviour[] allScripts = FindObjectsOfType<MonoBehaviour>();
        List<AllInterafce.IEnigmaCore> allEnigmaCores = new List<AllInterafce.IEnigmaCore>();
        
        for (int i = 0; i < allScripts.Length; i++)
        {
            if(allScripts[i] is AllInterafce.IEnigmaCore)
                allEnigmaCores.Add(allScripts[i] as AllInterafce.IEnigmaCore);
        }

        foreach (var enigmaCore in allEnigmaCores)
        {
            if (enigmaCore._enigmaType == _enigmaTypeToUnlock)
            {
                enigmaCore.UnlockNextEnigme();
            }
        }
    }
}
