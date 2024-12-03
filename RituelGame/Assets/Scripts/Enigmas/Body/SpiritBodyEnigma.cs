using System.Linq;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpiritBodyEnigma : MonoBehaviour
{
    public GameObject AllBodyParent;
    public SerializedDictionary<string, Sprite> _bodyData = new SerializedDictionary<string, Sprite>();
    
    private void Start()
    {
        Initialise();
    }

    private void Initialise()
    {
        for (int i = 0; i < AllBodyParent.transform.childCount; i++)
        {
            GameObject child = null;
            child = AllBodyParent.transform.GetChild(i).gameObject;

            child.transform.GetChild(0).GetComponent<Image>().sprite = _bodyData.ElementAt(i).Value;
            child.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = _bodyData.ElementAt(i).Key;
        }
    }
}
