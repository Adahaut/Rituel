using System.Collections;
using System.Collections.Generic;
using Enigmas;
using UnityEngine;
using UnityEngine.UI;

public class EnigmaCryptexCore : MonoBehaviour
{
    public Sprite _cryptexOpen;
    public GameObject _cryptexSprite;

    public Vector3 OffSet;
    
    public GameObject _cryptexBackGround;
    public GameObject _codePanel;
    
    public EnigmaData _cryptexData;

    public LinkCore linkCore;

    public List<char> values = new();

    public string _answer;
    private string guess = "";
    
    public Canvas _canvasParent;
    public GameObject _buttonToAccessEnigma;

    public GameObject _mazeButton;

    public void CheckingIfStringIsCorrect(int value)
    {
        guess += values[value].ToString();

        if (guess.Length == 5)
        {
            if (guess == _answer)
            {
                Win();
            }
            else
            {
                Lose();
                guess = "";
            }
        }
    }

    public void Win()
    {
        _buttonToAccessEnigma.SetActive(false);
        linkCore.AddLink(_cryptexData.LinkToAddIfSuccess);
        _cryptexData.GetReward();
        
        _cryptexBackGround.GetComponent<Image>().sprite = _cryptexOpen;
        _cryptexSprite.transform.position -= OffSet;
        StartCoroutine(PanelCode());
        
        _mazeButton.GetComponent<EnigmaButton>().ActivateEnigma();
    }
    
    public void Lose()
    {
        linkCore.RemoveLink(_cryptexData.LinkToRemoveIfFail);
    }

    private IEnumerator PanelCode()
    {
        yield return new WaitForSeconds(1f);
        _codePanel.SetActive(true);
    }
}
