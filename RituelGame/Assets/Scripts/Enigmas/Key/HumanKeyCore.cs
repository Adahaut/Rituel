using Enum;
using UnityEngine;

namespace Enigmas.Key
{
    public class HumanKeyCore : MonoBehaviour, IKeyCore
    {
        [field:SerializeField] public KeyEnigmaData _KeyEnigmaData { get; private set; }
        
        public void SetEnigmaData(KeyEnigmaData enigmaData)
        {
            _KeyEnigmaData = enigmaData;
        }

        private void OnKeyTurned(KeyTurnSide side)
        {
            
        }
    }
}