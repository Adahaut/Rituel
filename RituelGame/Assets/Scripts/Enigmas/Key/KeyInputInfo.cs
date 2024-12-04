using AYellowpaper.SerializedCollections;
using Enum;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class KeyInputInfo : MonoBehaviour
{
    [SerializeField] private Image imageSide;
    [SerializeField] private TextMeshProUGUI textAmount;

    [SerializeField] private SerializedDictionary<KeyTurnSide, Sprite> turnSideSprites;
    
    public void SetInfo(KeyTurnSide turnSide, int sideAmount)
    {
        imageSide.sprite = turnSideSprites[turnSide];
        textAmount.text = sideAmount.ToString();
    }
}
