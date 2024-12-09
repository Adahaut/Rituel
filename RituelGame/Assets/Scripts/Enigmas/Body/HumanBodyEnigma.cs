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
    public Canvas _canvasParent;
    public GameObject _buttonToAccessEnigma;
    
    private void Start()
    {
        bodyIndex = Random.Range(0, _bodyData.Count);

        GameObject body = Instantiate(_bodyData.ElementAt(bodyIndex).Value, _bodyParent.transform, true);
        body.GetComponentInChildren<TextMeshProUGUI>().text = "";
        body.transform.localPosition = Vector3.zero;
        body.transform.localScale = Vector3.one;
    }

    public void SubmitAnswer(string bodyName)
    {
        if (string.Equals(_bodyData.ElementAt(bodyIndex).Key, bodyName, StringComparison.OrdinalIgnoreCase))
        {
            _canvasParent.gameObject.SetActive(false);
            _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);
        }
        else
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
        }
    }
}
