using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public int paternNumber = 0;
    const int maxPaternNumber = 2;

    private void Start()
    {
        paternNumber = 0;
    }

    public int[,] Paterns()
    {
        paternNumber = Random.Range(0, maxPaternNumber);
        Debug.Log(paternNumber);
        
        switch (paternNumber)
        {
            case 0:
                paternNumber++;
                return firstMazePatern;
            case 1:
                paternNumber++;
                return secondMazePatern;
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
        }

        return null;
    }

    public Vector2 SetPawnBasePosition()
    {
        switch (paternNumber)
        {
            case 0:
                return firstMazePawnBasePosition;
            case 1:
                return secondMazePawnBasePosition;
            
            case maxPaternNumber:
                paternNumber = 0;
                return SetPawnBasePosition();
        }

        return Vector2.zero;
    }
}
