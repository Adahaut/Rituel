using System;
using System.Collections;
using System.Collections.Generic;
using Enigmas;
using Particles;
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
    
    public LayoutGroup _horizontalLayoutGroup;
    
    [SerializeField] private AudioManager audioManager;
    
    [SerializeField] private GameObject correctBreakParticles;
    [SerializeField] private GameObject wrongBreakParticles;
    [SerializeField] private GameObject breakRelicParticles;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        symbole = Random.Range(0, _relics.Count);
        _symboleText.text = symbole.ToString();
        _horizontalLayoutGroup.enabled = false;
    }

    public bool CheckRelicSymbole(RelicItem relic)
    {
        audioManager.PlayOverlap("BreakRelic");
        Vector3 particlePos = relic.transform.position;
        particlePos.z = ParticlesConst.ParticleZSpawn;
        Instantiate(breakRelicParticles, transform).transform.position = particlePos;
        if (relic._symbole != symbole)
        {
            linkCore.RemoveLink(enigmaData.LinkToRemoveIfFail);
            _codePanel.SetActive(false);
            Instantiate(wrongBreakParticles, transform).transform.position = particlePos;
        }
        else
        {
            _codePanel.SetActive(true);
            _enigma.SetActive(false);
            _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
            _buttonToAccessEnigma.GetComponent<EnigmaButton>()._enigmaFinish = true;
            linkCore.AddLink(enigmaData.LinkToAddIfSuccess);
            Instantiate(correctBreakParticles, transform).transform.position = particlePos;
        }

        return relic._symbole == symbole;
    }
}
