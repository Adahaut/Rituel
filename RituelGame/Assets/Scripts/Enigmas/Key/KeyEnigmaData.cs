using System.Collections.Generic;
using Enum;
using UnityEngine;

namespace Enigmas.Key
{
    [CreateAssetMenu(fileName = "KeyEnigmaData", menuName = "KeyEnigma")]
    public class KeyEnigmaData : ScriptableObject
    {
        public List<KeyTurnSide> _sideTurnList = new();
    }
}