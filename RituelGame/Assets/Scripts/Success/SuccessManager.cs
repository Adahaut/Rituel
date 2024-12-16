using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class SuccessManager : MonoBehaviour
{
    public SerializedDictionary<SuccesType, GameObject> _allSuccess;

    public GameObject _parentInCanvasToSpawn;

    public GameObject _parentToSpawnWhenUnlock;

    private Queue<SuccesType> spawnQueue;
    private Coroutine spawnDelayed;

    private void Start()
    {
        spawnQueue = new Queue<SuccesType>();
        ResetAllSuccess();
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
        spawnQueue.Enqueue(successType);
        spawnDelayed ??= StartCoroutine(SpawnSuccesDelay(1.5f));
    }

    public void ResetAllSuccess()
    {
        foreach (var success in _allSuccess.Values)
        {
            success.GetComponent<SuccessObject>()._successData.LockSuccess();
        }
    }

    public IEnumerator SpawnSuccesDelay(float delay)
    {
        while (spawnQueue.Count > 0)
        {
            for (int i = 0; i < _allSuccess.Count; i++)
            {
                if (_allSuccess.ElementAt(i).Key == spawnQueue.Peek())
                {
                    GameObject obj;
                    obj = Instantiate(_allSuccess.ElementAt(i).Value, _parentToSpawnWhenUnlock.transform);
                    obj.GetComponent<SuccessObject>().Unlock();
                    spawnQueue.Dequeue();
                    yield return new WaitForSeconds(delay);
                }
            }
        }

        spawnDelayed = null;
    }
}
