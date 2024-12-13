using System;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class SuccessManager : MonoBehaviour
{
    public SerializedDictionary<SuccesType, GameObject> _allSuccess;

    public GameObject _parentInCanvasToSpawn;

    public GameObject _parentToSpawnWhenUnlock;

    private void Start()
    {
        SpawnAllSucessMenu();
    }

    public void SpawnAllSucessMenu()
    {
        foreach (GameObject success in _allSuccess.Values)
        {
            Instantiate(success, _parentInCanvasToSpawn.transform);
        }
    }

    public void SpawnSuccess(SuccesType successType)
    {
        for (int i = 0; i < _allSuccess.Count; i++)
        {
            if (_allSuccess.ElementAt(i).Key == successType)
            {
                GameObject obj;
                obj = Instantiate(_allSuccess.ElementAt(i).Value, _parentToSpawnWhenUnlock.transform);
                obj.GetComponent<SuccessObject>().Unlock();
            }
        }
    }

    public void ResetAllSuccess()
    {
        foreach (var success in _allSuccess.Values)
        {
            success.GetComponent<SuccessObject>()._successData.LockSuccess();
        }
    }
}
