using System;
using DG.Tweening;
using Enigmas.Ouija;
using UnityEngine;
using OuijaCharacter = Enigmas.Ouija.OuijaCharacter;

public class OuijaInputPanel : MonoBehaviour
{
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
    
    private GameObject layoutObjectPlaceholder;
    
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
        
        GameObject placeHolderObject = layoutObjectPlaceholder = 
            new GameObject("layoutPlaceholder", typeof(RectTransform));
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

        newOuijaTransform.DOScale(inputCharScale, scaleDuration)
            .SetEase(scaleEase).onComplete += () =>
        {
            newOuijaObj.gameObject.AddComponent<FollowTransform>().SetTarget(placeHolderObject.transform);
            newOuijaObj._canvasGroup.SetCanvasGroupInteraction(true);
            /*newOuijaTransform.DOMove(placeHolderObject.transform.position, moveDuration).SetUpdate(true)
                .SetEase(moveEase).onComplete += () =>
            {
                int siblingIndex = placeHolderObject.transform.GetSiblingIndex();
                Destroy(placeHolderObject);
                newOuijaTransform.SetParent(charInputParentLayout);
                newOuijaTransform.SetSiblingIndex(siblingIndex);
                
            };*/
        };
    }
}
