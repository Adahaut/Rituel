using UnityEngine;

namespace Enigmas.Key
{
    public class SpiritKeyCore : MonoBehaviour, IKeyCore
    {
        [field:SerializeField] public KeyEnigmaData _KeyEnigmaData { get; private set; }
        
        public void SetEnigmaData(KeyEnigmaData enigmaData)
        {
            _KeyEnigmaData = enigmaData;
        }
    }
}