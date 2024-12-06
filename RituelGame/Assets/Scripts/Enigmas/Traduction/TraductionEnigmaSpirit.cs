using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TraductionEnigmaSpirit : MonoBehaviour, AllInterafce.IEnigmaCore
{
    
    public EnigmaData _enigmaData;
    
    public SerializedDictionary<string, string> _wordEnglishToLatin = new SerializedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    public List<string> _phrases;
    public TextMeshProUGUI _phraseToTranslate;

    public GameObject wordsParent;

    public Vector2 _topLeftFirstButtonPos;

    private int phraseIndex;
    private string actualPhrase;
    private string[] words;
    private int wordCompletionIndex;

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
        
        foreach (string word in words)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                GameObject obj = new GameObject(word);
                obj.transform.SetParent(wordsParent.transform);

                GameObject text = new GameObject("Text");
                text.transform.SetParent(obj.transform);
                TextMeshProUGUI textMesh = text.AddComponent<TextMeshProUGUI>();
                textMesh.text = _wordEnglishToLatin[word];
                textMesh.fontSize = 24;
                textMesh.horizontalAlignment = HorizontalAlignmentOptions.Center;
                textMesh.verticalAlignment = VerticalAlignmentOptions.Middle;

                Button button = obj.AddComponent<Button>();
                Image image = obj.AddComponent<Image>();
                image.color = Color.black;
                button.image = image;

                button.onClick.AddListener(() => ChooseAnswer(word));

                obj.transform.localPosition = new Vector3(_topLeftFirstButtonPos.x + (150 * index), _topLeftFirstButtonPos.y, -0f);
                obj.transform.localScale = Vector3.one;

                index++;
            }
        }
    }

    private void ChooseAnswer(string word)
    {
        if (string.Equals(word, words[wordCompletionIndex]))
        {
            Debug.Log($"Correct: {word}");
            wordCompletionIndex++;
            if (wordCompletionIndex == words.Length)
            {
                Debug.Log("Success! Phrase complete.");
                _enigmaData.GetReward();
            }
        }
        else
        {
            Debug.Log("Failed, wrong word selected.");
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
