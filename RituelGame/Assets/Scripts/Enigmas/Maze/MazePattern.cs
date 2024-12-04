using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public struct MazeStruct
{
    public int[,] _mazePattern;
    public Vector2 _mazePawnBasePosition;
    public float _mazeRotation;
    public GameObject _mazeWindRose;
}

public class MazePattern : MonoBehaviour
{
    public List<GameObject> _mazeWindRoses = new();
    
    public int[,] firstMazePattern =
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
    
    public int[,] secondMazePattern =
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
    
    public int[,] thirdMazePattern =
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
    
    public int[,] fourthMazePattern =
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

    public MazeStruct firstMazeStruct = new();
    public MazeStruct secondMazeStruct = new();
    public MazeStruct thirdMazeStruct = new();
    public MazeStruct fourthMazeStruct = new();
    
    public UnityEvent<MazeStruct> onMazePatternLoaded = new();

    private void OnEnable()
    {
        InitStructMaze(firstMazeStruct, firstMazePattern, Vector2.one, 0.0f, _mazeWindRoses[0]);
        InitStructMaze(secondMazeStruct, secondMazePattern, new Vector2(10f, 1f), -90f, _mazeWindRoses[1]);
        InitStructMaze(thirdMazeStruct, thirdMazePattern, new Vector2(10f, 10f), 180f, _mazeWindRoses[2]);
        InitStructMaze(fourthMazeStruct, fourthMazePattern, new Vector2(1f, 10f), 90f, _mazeWindRoses[3]);
    }

    private void InitStructMaze(MazeStruct mazeStruct, int[,] mazePattern, Vector2 mazePawnBasePosition, float mazeRotation, GameObject mazeWindRose)
    {
        mazeStruct._mazePattern = mazePattern;
        mazeStruct._mazePawnBasePosition = mazePawnBasePosition;
        mazeStruct._mazeRotation = mazeRotation;
        mazeStruct._mazeWindRose = mazeWindRose;
        
        onMazePatternLoaded.Invoke(mazeStruct);
    }
    public int _maxPaternNumber = 4;

    public MazeStruct GetRandomStruct()
    {
        switch (Random.Range(0, _maxPaternNumber))
        {
            case 0 :
                return firstMazeStruct;
            case 1 :
                return secondMazeStruct;
            case 2 :
                return thirdMazeStruct;
            case 3 :
                return fourthMazeStruct;
        }

        return new MazeStruct();
    }
}
