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
    public SerializedDictionary<string, Sprite> _bodyData = new SerializedDictionary<string, Sprite>();

    private void Start()
    {
        bodyIndex = Random.Range(0, 9);

        _bodyImage.sprite = _bodyData.ElementAt(bodyIndex).Value;
        
        Debug.Log(_bodyData.ElementAt(bodyIndex).Key);
    }

    public void SubmitAnswer(string bodyName)
    {
        if (string.Equals(_bodyData.ElementAt(bodyIndex).Key, bodyName, StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Sucess");
        }
    }
}
