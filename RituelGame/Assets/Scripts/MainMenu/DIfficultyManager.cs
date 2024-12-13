using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DIfficultyManager : MonoBehaviour
{
    private int _linkToStartWith;

    public int _easyLink;
    public int _mediumLink;
    public int _hardLink;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "HumanScene" ||
            SceneManager.GetActiveScene().name == "SpiritScene")
        {
            LinkCore linkCore = GameObject.FindGameObjectWithTag("LinkManager").GetComponent<LinkCore>();
            
            linkCore.SetLinkCount(_linkToStartWith);
            
            Destroy(gameObject);
        }
    }
    
    public void Easy()
    {
        _linkToStartWith = _easyLink;
    }
    
    public void Medium()
    {
        _linkToStartWith = _mediumLink;
    }
    
    public void Hard()
    {
        _linkToStartWith = _hardLink;
    }
}
