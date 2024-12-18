using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using DG.Tweening;
using Enigmas;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TraductionEnigmaSpirit : MonoBehaviour
{
    public SerializedDictionary<string, string> _wordEnglishToLatin = new SerializedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    public List<string> _wordLatin = new();
    public List<string> _answer = new();
    
    public List<string> _phrases;
    public TextMeshProUGUI _phraseToTranslate;

    public EnigmaData _enigmaData;
    public LinkCore _linkCore;

    public GameObject wordsParent;

    public Vector2 _topLeftFirstButtonPos;

    public CanvasGroup enigmaCanvas;
    public float canvasFadeDuration;
    
    private int phraseIndex;
    private string actualPhrase;
    private string[] words;
    private int wordCompletionIndex;
    private int posIndex = 0;
    private List<GameObject> buttonListe = new();
    private int indexInList = 0;
    public GameObject _buttonToAccessEnigma;
    public Transform _buttonsTargetPosition;
    public float targetScale;

    private int nbWords;

    public GameObject _codePanel;
    public GameObject _enigma;
    
    public UnityEvent _onEnigmaComplete;

    private void Start()
    {
        phraseIndex = Random.Range(0, _phrases.Count);
        actualPhrase = _phrases[phraseIndex];
        words = actualPhrase.Split(' ');
        wordCompletionIndex = 0;
        indexInList = 0;
        _phraseToTranslate.text = actualPhrase.Replace(" ", "\n");

        foreach (string word in _wordEnglishToLatin.Values)
        {
            _wordLatin.Add(word);
        }
        
        Initialise();
    }

    private void Initialise()
    {
        _buttonsTargetPosition.position += new Vector3(0, 1f, 0) * nbWords;
        int index = 0;
        indexInList = 0;
        nbWords = 0;
        
        foreach (var word in _wordEnglishToLatin)
        {
            if (!string.IsNullOrWhiteSpace(word.Key))
            {
                if (index == _wordEnglishToLatin.Count / 2)
                {
                    _topLeftFirstButtonPos.y -= 150f;
                    index -= _wordEnglishToLatin.Count / 2;
                }
                    
                GameObject parentButton = new GameObject(word.Key);
                parentButton.transform.SetParent(wordsParent.transform);
                GameObject objButton = new GameObject("button");
                objButton.transform.SetParent(parentButton.transform);
                parentButton.transform.localScale = Vector3.one;

                GameObject text = new GameObject("Text");
                text.transform.SetParent(parentButton.transform);
                text.transform.localScale = Vector3.one;
                TextMeshProUGUI textMesh = text.AddComponent<TextMeshProUGUI>();
                textMesh.raycastTarget = false;
                textMesh.text = _wordEnglishToLatin[word.Key];
                textMesh.fontSize = 24;
                textMesh.horizontalAlignment = HorizontalAlignmentOptions.Center;
                textMesh.verticalAlignment = VerticalAlignmentOptions.Middle;

                Image image = objButton.AddComponent<Image>();
                image.color = Color.black;
                Button button = objButton.AddComponent<Button>();
                button.image = image;

                parentButton.AddComponent<ChangeScaleOnHover>();
                
                int buttonIndex = indexInList;

                button.onClick.AddListener(() => ChooseAnswer(word.Key, objButton, buttonIndex));

                parentButton.transform.localPosition = new Vector3(_topLeftFirstButtonPos.x + 350 + (150 * index), _topLeftFirstButtonPos.y, -0f);
                parentButton.transform.localScale = Vector3.one;

                buttonListe.Add(objButton);
                indexInList++;

                index++;
            }
        }
        _topLeftFirstButtonPos.y += 150f;
    }

    public void ResetButton()
    {
        foreach (Transform child in wordsParent.transform)
        {
            Destroy(child.gameObject);
        }
        
        _answer.Clear();
        buttonListe.Clear();
        
        Initialise();
    }

    private void CompleteEnigma()
    {
        foreach (GameObject button in buttonListe)
        {
            button.GetComponent<Button>().interactable = false;
        }
        
        _codePanel.SetActive(true);
        _enigma.SetActive(false);
        _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);

        _onEnigmaComplete.Invoke();

        _buttonToAccessEnigma.GetComponent<EnigmaButton>()._enigmaFinish = true;
    }
    
    private void ChooseAnswer(string word, GameObject button, int index)
    {
        _answer.Add(word.ToLower());
        
        button.GetComponent<Button>().interactable = false;
        
        Vector3 targetPosition = _buttonsTargetPosition.position;
        
        button.transform.parent.DOMove(targetPosition, 1f);
        _buttonsTargetPosition.position -= new Vector3(0, 1f, 0);
        button.GetComponent<Button>().transform.DOScale(new Vector3(targetScale, 1f, 1f), 1f);
        button.GetComponent<Image>().DOFade(0, 0.5f);
        button.transform.parent.GetComponentInChildren<TextMeshProUGUI>().DOColor(Color.black, 0.5f);
        button.transform.parent.GetComponentInChildren<TextMeshProUGUI>().transform.DOScale(new Vector3(targetScale, targetScale, 1f), 1f);
        
        posIndex++;
        wordCompletionIndex++;
        
        onWordChoosen();
    }

    public void CheckWin()
    {
        bool won = true;
        
        for (int i = 0; i < words.Length; i++)
        {
            if (_answer[i] != words[i].ToLower())
            {
                won = false;
            }
        }

        if (won)
        {
            CompleteEnigma();
            _linkCore.AddLink(_enigmaData.LinkToAddIfSuccess);
        }
        else
        {
            ResetButton();
            _linkCore.RemoveLink(_enigmaData.LinkToRemoveIfFail);
        }
    }

    private void onWordChoosen()
    {
        if (nbWords == words.Length)
        {
            nbWords += 1;
            ResetButton();
            return;
        }
        
        nbWords += 1;
    }
}
