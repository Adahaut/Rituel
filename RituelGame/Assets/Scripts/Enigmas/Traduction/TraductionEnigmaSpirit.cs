using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TraductionEnigmaSpirit : MonoBehaviour
{
    [SerializeField] private LinkCore linkCore;
    
    public SerializedDictionary<string, string> _wordEnglishToLatin = new SerializedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    public List<string> _phrases;
    public TextMeshProUGUI _phraseToTranslate;

    public GameObject wordsParent;

    public Vector2 _topLeftFirstButtonPos;

    public CanvasGroup enigmaCanvas;
    public float canvasFadeDuration;
    
    private int phraseIndex;
    private string actualPhrase;
    private string[] words;
    private int wordCompletionIndex;
    private int posIndex = 0;
    private List<GameObject> buttonListe = new List<GameObject>();
    public Canvas _canvasParent;
    public GameObject _buttonToAccessEnigma;

    private void Start()
    {
        phraseIndex = Random.Range(0, _phrases.Count);
        actualPhrase = _phrases[phraseIndex];
        words = actualPhrase.Split(' ');
        wordCompletionIndex = 0;
        _phraseToTranslate.text = actualPhrase;

        Debug.Log($"Phrase: {actualPhrase}");

        Initialise();
    }

    private void Initialise()
    {
        int index = 0;
        
        foreach (var word in _wordEnglishToLatin)
        {
            if (!string.IsNullOrWhiteSpace(word.Key))
            {
                GameObject obj = new GameObject(word.Key);
                obj.transform.SetParent(wordsParent.transform);

                GameObject text = new GameObject("Text");
                text.transform.SetParent(obj.transform);
                TextMeshProUGUI textMesh = text.AddComponent<TextMeshProUGUI>();
                textMesh.text = _wordEnglishToLatin[word.Key];
                textMesh.fontSize = 24;
                textMesh.horizontalAlignment = HorizontalAlignmentOptions.Center;
                textMesh.verticalAlignment = VerticalAlignmentOptions.Middle;

                Button button = obj.AddComponent<Button>();
                Image image = obj.AddComponent<Image>();
                image.color = Color.black;
                button.image = image;

                button.onClick.AddListener(() => ChooseAnswer(word.Key, obj));

                obj.transform.localPosition = new Vector3(_topLeftFirstButtonPos.x + (150 * index), _topLeftFirstButtonPos.y, -0f);
                obj.transform.localScale = Vector3.one;
                
                buttonListe.Add(obj);

                index++;
            }
        }
    }

    private void ResetButton()
    {
        posIndex = 0;
        wordCompletionIndex = 0;
        int index = 0;
        foreach (GameObject button in buttonListe)
        {
            button.transform.DOLocalMove(
                new Vector3(_topLeftFirstButtonPos.x + (150 * index), _topLeftFirstButtonPos.y, -0f), 1f);
            button.GetComponent<Button>().interactable = true;
            index++;
        }
        linkCore.RemoveLink(10);
    }

    private void CompleteEnigma()
    {
        foreach (GameObject button in buttonListe)
        {
            button.GetComponent<Button>().interactable = false;
        }
        
        enigmaCanvas.DOFade(0, canvasFadeDuration);
        enigmaCanvas.interactable = false;
        enigmaCanvas.blocksRaycasts = false;
        _canvasParent.gameObject.SetActive(false);
        _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        linkCore.AddLink(10);
    }
    
    private void ChooseAnswer(string word, GameObject button)
    {
        string wordLower = word.ToLower();
        string wordsActualLower = words[wordCompletionIndex].ToLower();
        
        if (string.Equals(wordLower, wordsActualLower))
        {
            Debug.Log($"Correct: {word}");
            wordCompletionIndex++;

            button.GetComponent<Button>().interactable = false;
            
            Vector3 wordPosition = GetWordPosition(wordCompletionIndex - 1);
            Vector3 targetPosition = new Vector3(wordPosition.x, wordPosition.y - 50, 0);
            
            button.transform.DOMove(new Vector3(targetPosition.x, 300, 0), 1f);

            posIndex++;
            
            if (wordCompletionIndex == words.Length)
            {
                CompleteEnigma();
            }
        }
        else
        {
            ResetButton();
        }
    }
    
    private Vector3 GetWordPosition(int wordIndex)
    {
        TMP_TextInfo textInfo = _phraseToTranslate.textInfo;
        
        TMP_WordInfo wordInfo = textInfo.wordInfo[wordIndex];

        Vector3 firstCharPosition = _phraseToTranslate.transform.TransformPoint(
            textInfo.characterInfo[wordInfo.firstCharacterIndex].bottomLeft
        );

        Vector3 lastCharPosition = _phraseToTranslate.transform.TransformPoint(
            textInfo.characterInfo[wordInfo.lastCharacterIndex].topRight
        );

        Vector3 wordPosition = (firstCharPosition + lastCharPosition) / 2f;

        return wordPosition;
    }
}
