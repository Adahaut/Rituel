using System;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HumanBodyEnigma : MonoBehaviour
{
    private int bodyIndex;

    public Image _bodyImage;
    public SerializedDictionary<string, Sprite> _bodyData = new SerializedDictionary<string, Sprite>(10);
    [SerializeField] private LinkCore linkCore;
    [SerializeField] private EnigmaData enigmaData;
    
    private void Start()
    {
        bodyIndex = Random.Range(0, _bodyData.Count);

        _bodyImage.sprite = _bodyData.ElementAt(bodyIndex).Value;
        
        Debug.Log(_bodyData.ElementAt(bodyIndex).Key);
    }

    public void SubmitAnswer(string bodyName)
    {
        if (string.Equals(_bodyData.ElementAt(bodyIndex).Key, bodyName, StringComparison.OrdinalIgnoreCase))
        {
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);
        }
        else
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
        }
    }
}
