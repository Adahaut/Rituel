using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpiritBodyEnigma : MonoBehaviour
{
    public GameObject AllBodyParent;
    public SerializedDictionary<string, GameObject> _bodyData = new SerializedDictionary<string, GameObject>();
    public List<String> _lastName;
    public List<int> _ages;
    public GameObject _bodyCanvas;
    public Image _buttonImage;
    [SerializeField] private LinkCore linkCore;
    [SerializeField] private EnigmaData enigmaData;
    
    private void Start()
    {
        Initialise();
    }

    private void Initialise()
    {
        for (int i = 0; i < _bodyData.Count; i++)
        {
            GameObject child = Instantiate(_bodyData.ElementAt(i).Value, AllBodyParent.transform, true);
            child.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            child.transform.GetComponentInChildren<TextMeshProUGUI>().text = _bodyData.ElementAt(i).Key;
            child.transform.GetComponentInChildren<TextMeshProUGUI>().text += " " + _lastName[i];
        }
    }

    public void SubmitAnswer(string answer)
    {
        if (_ages.Contains(int.Parse(answer)))
        {
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);
            _bodyCanvas.SetActive(false);
            _buttonImage.color = Color.gray;
        }
        else
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
        }
    }
}
