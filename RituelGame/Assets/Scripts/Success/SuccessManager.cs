using System;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class SuccessManager : MonoBehaviour
{
    public SerializedDictionary<string, GameObject> _allSuccess;

    public GameObject _parentInCanvasToSpawn;

    public void SpawnAllSucess()
    {
        foreach (GameObject success in _allSuccess.Values)
        {
            Instantiate(success, _parentInCanvasToSpawn.transform);
        }
    }

    public void SpawnSuccess(string successName)
    {
        for (int i = 0; i < _allSuccess.Count; i++)
        {
            if (string.Equals(_allSuccess.ElementAt(i).Key, successName, StringComparison.OrdinalIgnoreCase))
            {
                GameObject obj;
                obj = Instantiate(_allSuccess.ElementAt(i).Value, _parentInCanvasToSpawn.transform);
                obj.GetComponent<SuccessObject>().Unlock();
            }
        }
    }
}
