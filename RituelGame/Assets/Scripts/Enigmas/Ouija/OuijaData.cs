using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enigmas.Ouija
{
    [CreateAssetMenu(fileName = "OuijaData", menuName = "Ouija/OuijaData")]
    public class OuijaData : ScriptableObject
    {
        [field:SerializeField] public TMP_FontAsset _correctFontAsset { get; private set; }
        [field: SerializeField] public List<TMP_FontAsset> _falseFontAssets { get; private set; }
        [field:SerializeField] public List<char> _answerCharacters { get; private set; }
        [field:SerializeField] public List<char> _charsToDisplay { get; private set; }
    }
}