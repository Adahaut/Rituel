using System.Linq;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;

public class TraductionEnigmasHuman : MonoBehaviour, AllInterafce.IEnigmaCore
{
    public GameObject _latinParent;
    public GameObject _englishParent;
    public SerializedDictionary<string, string> _wordEnglishToLatin;

    private void Start()
    {
        Initialise();
    }

    public void Initialise()
    {
        for (int i = 0; i < _latinParent.transform.childCount; i++)
        {
            GameObject child;
            child = _latinParent.transform.GetChild(i).gameObject;

            child.GetComponent<TextMeshProUGUI>().text = _wordEnglishToLatin.ElementAt(i).Value;
        }
        
        for (int i = 0; i < _englishParent.transform.childCount; i++)
        {
            GameObject child;
            child = _englishParent.transform.GetChild(i).gameObject;

            child.GetComponent<TextMeshProUGUI>().text = _wordEnglishToLatin.ElementAt(i).Key;
        }
    }

    [field:SerializeField]
    public EnigmaType _enigmaType { get; set; }
    [field:SerializeField]
    public GameObject _unlockButtonThisEnigma { get; set; }
    
    public void UnlockNextEnigme()
    {
        if (_unlockButtonThisEnigma)
        {
            _unlockButtonThisEnigma.SetActive(true);   
        }
    }
}
