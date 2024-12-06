using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class RelicController : MonoBehaviour
{
    private int symbole;
    public List<RelicItem> _relics = new(3);
    public TextMeshProUGUI _symboleText;
    [SerializeField] private LinkCore linkCore;
    [SerializeField] private EnigmaData enigmaData;

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
        if (relic._symbole != symbole)
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
            Destroy(relic.gameObject);
        }
        else
        {
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);
        }
    }
}
