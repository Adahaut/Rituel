using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HumanBodyEnigma : MonoBehaviour
{
    private int bodyIndex;

    public Image _bodyImage;
    public Dictionary<int, string> _bodyData = new Dictionary<int, string>();

    private void Start()
    {
        bodyIndex = Random.Range(0, 9);
        
        _bodyData.Add(1, "a");
        _bodyData.Add(2, "b");
        _bodyData.Add(3, "c");
        _bodyData.Add(4, "d");
        _bodyData.Add(5, "e");
        _bodyData.Add(6, "f");
        _bodyData.Add(7, "g");
        _bodyData.Add(8, "h");
        _bodyData.Add(9, "i");
        _bodyData.Add(10, "j");

        //_bodyImage.sprite = _bodyData.ElementAt(bodyIndex).Key;
        
        Debug.Log(_bodyData.ElementAt(bodyIndex).Value);
    }

    public void SubmitAnswer(string bodyName)
    {
        if (string.Equals(_bodyData.ElementAt(bodyIndex).Value, bodyName, StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("Sucess");
        }
    }
}
