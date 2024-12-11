using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Enigmas;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpiritBodyEnigma : MonoBehaviour
{
    public GameObject AllBodyParent;
    public SerializedDictionary<string, GameObject> _bodyData = new SerializedDictionary<string, GameObject>();
    public List<String> _lastName;
    public List<int> _ages;
    public GameObject _buttonToAccessEnigma;
    [SerializeField] private LinkCore linkCore;
    [SerializeField] private EnigmaData enigmaData;
    private GameObject child;
    private int corpseIndex;
    private int maxIndex = 9;
    private int minIndex = 0;

    public GameObject _enigma;
    public GameObject _codePanel;

    public UnityEvent _onEnigmaCompleted;
    
    private void Start()
    {
        Initialise();
    }

    private void Initialise()
    {
        for (int i = 0; i < _bodyData.Count; i++)
        {
            child = Instantiate(_bodyData.ElementAt(i).Value, AllBodyParent.transform);
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
            _enigma.SetActive(false);
            _codePanel.SetActive(true);

            _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            _onEnigmaCompleted.Invoke();

            _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            _buttonToAccessEnigma.GetComponent<EnigmaButton>()._enigmaFinish = true;

        }
        else
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
        }
    }
}
