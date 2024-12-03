using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Enigmas.Ouija
{
    public class OuijaCharacter : MonoBehaviour
    {
        [field:SerializeField] public TextMeshProUGUI _humanCharacter { get; private set; }
        [field:SerializeField] public Image _spiritCharacter { get; private set; }
    }
}