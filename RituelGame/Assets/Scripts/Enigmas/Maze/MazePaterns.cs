using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MazePaterns : MonoBehaviour
{
    public int[,] firstMazePatern =
    {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1 },
        { 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1 },
        { 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1 },
        { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1 },
        { 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1 },
        { 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1, 1 },
        { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1 },
        { 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1 },
        { 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1 },
        { 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    [SerializeField] private Vector2 firstMazePawnBasePosition;
    [SerializeField] private float firstMazeRotation;
    [SerializeField] private GameObject firstMazeWindRose;
    
    public int[,] secondMazePatern =
    {
        { 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 1 },
        { 1, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 1 },
        { 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1 },
        { 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1 },
        { 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1 },
        { 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 1 },
        { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };
    
    [SerializeField] private Vector2 secondMazePawnBasePosition;
    [SerializeField] private float secondMazeRotation;
    [SerializeField] private GameObject secondMazeWindRose;
    
    public int[,] thirdMazePatern =
    {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1 },
        { 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
        { 2, 0, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1 },
        { 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1 },
        { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1 },
        { 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1, 1 },
        { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1 },
        { 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1 },
        { 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 1 },
        { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };
    
    [SerializeField] private Vector2 thirdMazePawnBasePosition;
    [SerializeField] private float thirdMazeRotation;
    [SerializeField] private GameObject thirdMazeWindRose;
    
    public int[,] forthMazePatern =
    {
        { 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1 },
        { 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1 },
        { 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1 },
        { 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 1 },
        { 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1 },
        { 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1 },
        { 1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 0, 1 },
        { 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1 },
        { 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1 },
        { 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };
    
    [SerializeField] private Vector2 forthMazePawnBasePosition;
    [SerializeField] private float forthMazeRotation;
    [SerializeField] private GameObject forthMazeWindRose;

    public int _paternNumber = 0;
    public int _maxPaternNumber = 4;
    const int maxPaternNumber = 4;

    private void Start()
    {
        _paternNumber = 0;
    }

    public int[,] Paterns()
    {
        _paternNumber = Random.Range(0, _maxPaternNumber);
        Debug.Log(_paternNumber);
        
        switch (_paternNumber)
        {
            case 0:
                return firstMazePatern;
            case 1:
                return secondMazePatern;
            case 2:
                return thirdMazePatern;
            case 3:
                return forthMazePatern;
        }

        return null;
    }

    public int[,] SpiritMaze(int paternIndex)
    {
        switch (paternIndex)
        {
            case 0 :
                return firstMazePatern;
            case 1 :
                return secondMazePatern;
            case 2 :
                return thirdMazePatern;
            case 3 :
                return forthMazePatern;
        }

        return null;
    }

    public Vector2 SetPawnBasePosition()
    {
        switch (_paternNumber)
        {
            case 0:
                return firstMazePawnBasePosition;
            case 1:
                return secondMazePawnBasePosition;
            case 2:
                return thirdMazePawnBasePosition;
            case 3:
                return forthMazePawnBasePosition;
            
            case maxPaternNumber:
                _paternNumber = 0;
                return SetPawnBasePosition();
        }

        return Vector2.zero;
    }

    public float SetMazeRotation(int paternIndex)
    {
        switch (paternIndex)
        {
            case 0:
                return firstMazeRotation;
            case 1:
                return secondMazeRotation;
            case 2:
                return thirdMazeRotation;
            case 3:
                return forthMazeRotation;
        }

        return 0;
    }

    public GameObject GetWindRoseSprite(int paternIndex)
    {
        switch (paternIndex)
        {
            case 0:
                return firstMazeWindRose;
            case 1:
                return secondMazeWindRose;
            case 2:
                return thirdMazeWindRose;
            case 3:
                return forthMazeWindRose;
        }
        
        return null;
    }
}
