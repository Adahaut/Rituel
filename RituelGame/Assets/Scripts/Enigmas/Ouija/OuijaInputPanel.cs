using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Enigmas.Ouija;
using UnityEngine;
using OuijaCharacter = Enigmas.Ouija.OuijaCharacter;

public class OuijaInputPanel : MonoBehaviour
{
    [SerializeField] private SpiritOuijaCore spiritOuijaCore;
    [SerializeField] private OuijaCharacter charInputPrefab;

    [SerializeField] private OuijaSpiritCursor spiritCursor;
    
    [SerializeField] private Transform charInputParentLayout;
    [SerializeField] private Transform charAnimationParent;
    
    [SerializeField] private float scaleDuration = 0.5f; 
    [SerializeField] private float inputCharScale = 1.25f;
    [SerializeField] private Ease scaleEase = Ease.InOutQuint;
    
    [SerializeField] private float moveDuration = 1;
    [SerializeField] private Ease moveEase = Ease.OutQuint;

    [SerializeField] private int maxInputCount = 7;
    
    private List<char> charList = new List<char>();

    private bool isInAnimation = false;
    
    private void Awake()
    {
        spiritCursor.OnOuijaCharacterSelectedEvent += OnOuijaCharacterSelected;
    }

    private void OnOuijaCharacterSelected(OuijaCharacter ouijaCharacter)
    {
        if (charInputParentLayout.childCount >= maxInputCount)
        {
            return;
        }
        
        char ouijaChar = ouijaCharacter._textMeshPro.text[0];
        charList.Add(ouijaChar);
        
        GameObject placeHolderObject = new GameObject("layoutPlaceholder", typeof(RectTransform));
        placeHolderObject.transform.SetParent(charInputParentLayout);
        placeHolderObject.transform.localScale = Vector3.one * inputCharScale;
        
        OuijaCharacter newOuijaObj = Instantiate(charInputPrefab, charAnimationParent);
        RectTransform newOuijaTransform = newOuijaObj._rectTransform;
        newOuijaTransform.position = ouijaCharacter.transform.position;
        newOuijaTransform.sizeDelta = ouijaCharacter._rectTransform.sizeDelta;
        newOuijaTransform.localScale = ouijaCharacter.transform.localScale;
        
        newOuijaObj._textMeshPro.text = ouijaChar.ToString();
        newOuijaObj._textMeshPro.fontSize = ouijaCharacter._textMeshPro.fontSize;
        newOuijaObj._textMeshPro.font = ouijaCharacter._textMeshPro.font;
        newOuijaObj._canvasGroup.SetCanvasGroupInteraction(false);

        isInAnimation = true;

        newOuijaTransform.DOScale(inputCharScale, scaleDuration)
            .SetEase(scaleEase).onComplete += () =>
        {
            FollowTransform followTransform = newOuijaObj.gameObject.AddComponent<FollowTransform>();
            followTransform.SetTarget(placeHolderObject.transform);
            followTransform.floatAmount = 0.05f;

            OuijaCharacterButton newOuijaCharacterButton = newOuijaObj.gameObject.GetComponent<OuijaCharacterButton>();
            newOuijaCharacterButton.Init(this);
            
            newOuijaObj._canvasGroup.SetCanvasGroupInteraction(true);

            isInAnimation = false;
        };
    }

    public void RemoveChar(GameObject charObject)
    {
        char charToRemove = charObject.GetComponent<OuijaCharacter>()._textMeshPro.text[0];
        int siblingIndex = charObject.transform.GetSiblingIndex();
        charList.RemoveAt(siblingIndex);
        Destroy(charInputParentLayout.GetChild(siblingIndex).gameObject);
        Destroy(charObject);
    }

    public void ConfirmInput()
    {
        spiritOuijaCore.OnConfirmAnswer(charList.ToList());
    }
}
