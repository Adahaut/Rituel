using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HumanBodyEnigma : MonoBehaviour
{
    private int bodyIndex;

    public GameObject _bodyParent;
    [SerializeField] private float bodyScale;
    
    public SerializedDictionary<string, GameObject> _bodyData = new SerializedDictionary<string, GameObject>(10);
    public List<int> _age;
    public List<string> _lastName;
    [SerializeField] private LinkCore linkCore;
    [SerializeField] private EnigmaData enigmaData;
    public Canvas _canvasParent;
    public GameObject _buttonToAccessEnigma;
    private GameObject body;
    public GameObject _question;
    public GameObject _answerZone;

    public GameObject _confirmButton;
    
    private void Start()
    {
        bodyIndex = Random.Range(0, _bodyData.Count);

        body = Instantiate(_bodyData.ElementAt(bodyIndex).Value, _bodyParent.transform, true);
        TextMeshProUGUI textMesh = body.GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = "";
        textMesh.gameObject.transform.position = _bodyParent.transform.position - new Vector3(200, 0, 0);
        body.transform.localPosition = Vector3.zero;
        body.transform.localScale = Vector3.one * bodyScale;
    }

    public void SubmitAnswer(string bodyName)
    {
        if (string.Equals(_bodyData.ElementAt(bodyIndex).Key, bodyName, StringComparison.OrdinalIgnoreCase))
        {
            _question.SetActive(false);
            _answerZone.SetActive(false);
            body.GetComponentInChildren<TextMeshProUGUI>().text =
                _bodyData.ElementAt(bodyIndex).Key + "\n" + _lastName[bodyIndex] + "\n" + _age[bodyIndex] + " years old";
            // _canvasParent.gameObject.SetActive(false);
            // _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);
            _confirmButton.SetActive(true);
        }
        else
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
        }
    }
}
