using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using Enigmas.Ouija;
using UnityEngine;
using UnityEngine.EventSystems;

public class OuijaBoard : MonoBehaviour, IPointerClickHandler
{
    private OuijaCore ouijaCore;
    [field:SerializeField] public SerializedDictionary<char, OuijaCharacter> _characterObjects { get; private set; }
    public Action OnBoardClickedEvent;

    public void SetOuijaCore(OuijaCore newOuijaCore)
    {
        ouijaCore = newOuijaCore;
    }
    
    public void DrawCharacters()
    {
        foreach (OuijaCharacter ouijaCharacter in _characterObjects.Keys.Select(character => _characterObjects[character]))
        {
            if (ouijaCore._currentWorld == WorldType.Human)
            {
                ouijaCharacter._humanCharacter.gameObject.SetActive(true);
                ouijaCharacter._spiritCharacter.gameObject.SetActive(false);
            }
            else
            {
                ouijaCharacter._humanCharacter.gameObject.SetActive(false);
                ouijaCharacter._spiritCharacter.gameObject.SetActive(true);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnBoardClickedEvent.Invoke();
    }
}
