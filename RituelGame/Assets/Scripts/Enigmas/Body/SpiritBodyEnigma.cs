using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpiritBodyEnigma : MonoBehaviour
{
    public GameObject AllBodyParent;
    public Dictionary<int, string> _bodyData = new Dictionary<int, string>();

    private void Start()
    {
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
        
        Initialise();
    }

    private void Initialise()
    {
        for (int i = 0; i < AllBodyParent.transform.childCount; i++)
        {
            GameObject child = null;
            child = AllBodyParent.transform.GetChild(i).gameObject;

            //child.transform.GetChild(0).GetComponent<Image>().sprite = _bodyData.ElementAt(i).Key;
            child.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _bodyData.ElementAt(i).Value;
        }
    }
}
