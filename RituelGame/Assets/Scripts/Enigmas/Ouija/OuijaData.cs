using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Enigmas.Ouija
{
    [CreateAssetMenu(fileName = "OuijaData", menuName = "Ouija/OuijaData")]
    public class OuijaData : ScriptableObject
    {
        [field:SerializeField] public List<char> _answerCharacters { get; private set; }
        
        [field:SerializeField] public SerializedDictionary<char, Sprite> _ouijaCharacters { get; private set; }
    }
}