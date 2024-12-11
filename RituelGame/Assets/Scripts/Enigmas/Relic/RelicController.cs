using System;
using System.Collections;
using System.Collections.Generic;
using Enigmas;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RelicController : MonoBehaviour
{
    private int symbole;
    public List<RelicItem> _relics = new(3);
    public TextMeshProUGUI _symboleText;
    [SerializeField] private LinkCore linkCore;
    [SerializeField] private EnigmaData enigmaData;
    public GameObject _buttonToAccessEnigma;
    public GameObject _codePanel;
    public GameObject _enigma;
    
    [SerializeField] private AudioManager audioManager;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        symbole = Random.Range(0, _relics.Count);
        _symboleText.text = symbole.ToString();
    }

    public void CheckRelicSymbole(RelicItem relic)
    {
        Destroy(relic.gameObject);
        audioManager.PlayOverlap("BreakRelic");
        if (relic._symbole != symbole)
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
        }
        else
        {
            _codePanel.SetActive(true);
            _enigma.SetActive(false);
            _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            _buttonToAccessEnigma.GetComponent<EnigmaButton>()._enigmaFinish = true;
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);
        }
    }
}
