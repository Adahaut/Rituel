using System;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Enigmas.Ouija;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class OuijaBoard : MonoBehaviour, IPointerClickHandler
{
    private IOuijaCore ouijaCore;

    [SerializeField] private Transform ouijaCharacterParent;
    [SerializeField] private OuijaCharacter ouijaCharacterPrefab;
    [field: SerializeField] public SerializedDictionary<char, OuijaCharacter> _characterObjects { get; private set; } = new();
    public Action<OuijaBoard> OnBoardClickedEvent;

    public void SetOuijaCore(IOuijaCore newOuijaCore)
    {
        ouijaCore = newOuijaCore;
    }
    
    public void DrawCharacters(TMP_FontAsset fontAsset)
    {
        EraseCharacters();
        _characterObjects = new SerializedDictionary<char, OuijaCharacter>();
        
        OuijaData ouijaData = ouijaCore._ouijaData;
        List<char> charactersToPlace = ouijaData._charsToDisplay.ToList();
        while (charactersToPlace.Count > 0)
        {
            OuijaCharacter newOuijaChar = Instantiate(ouijaCharacterPrefab, ouijaCharacterParent);
            int randomIndex = Random.Range(0, charactersToPlace.Count);
            char placingChar = charactersToPlace[randomIndex];
            newOuijaChar._textMeshPro.text = placingChar.ToString();
            newOuijaChar._textMeshPro.font = fontAsset;
            _characterObjects.Add(placingChar, newOuijaChar);
            charactersToPlace.Remove(placingChar);
        }
    }

    private void EraseCharacters()
    {
        foreach (Transform child in ouijaCharacterParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnBoardClickedEvent.Invoke(this);
    }
}
