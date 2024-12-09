using System.Linq;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpiritBodyEnigma : MonoBehaviour
{
    public GameObject AllBodyParent;
    public SerializedDictionary<string, GameObject> _bodyData = new SerializedDictionary<string, GameObject>();
    
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
        }
    }
}
