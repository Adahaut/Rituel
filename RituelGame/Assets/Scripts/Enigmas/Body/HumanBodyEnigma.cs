using System;
using System.Linq;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HumanBodyEnigma : MonoBehaviour
{
    private int bodyIndex;

    public GameObject _bodyParent;
    
    public SerializedDictionary<string, GameObject> _bodyData = new SerializedDictionary<string, GameObject>(10);
    [SerializeField] private LinkCore linkCore;
    [SerializeField] private EnigmaData enigmaData;
    
    private void Start()
    {
        bodyIndex = Random.Range(0, _bodyData.Count);

        GameObject body = Instantiate(_bodyData.ElementAt(bodyIndex).Value, _bodyParent.transform, true);
        body.GetComponentInChildren<TextMeshProUGUI>().text = "";
        body.transform.localPosition = Vector3.zero;
        body.transform.localRotation = Quaternion.Euler(0, 0, 0);
        
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
