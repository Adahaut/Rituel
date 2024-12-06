using UnityEngine;

public class AllInterafce : MonoBehaviour
{
    public interface IEnigmaCore
    {
        public EnigmaType _enigmaType { get; set; }
        public GameObject _unlockButtonThisEnigma { get; set; }
        public void UnlockNextEnigme();
    }
}
