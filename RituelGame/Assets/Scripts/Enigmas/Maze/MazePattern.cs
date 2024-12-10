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
    public string _mazeLayer;
}

public class MazePattern : MonoBehaviour
{
    public List<GameObject> _mazeWindRoses = new();

    public EnigmaMazeCoreHuman enigmaMazeCoreHuman;
    public EnigmaMazeCoreSpirit enigmaMazeCoreSpirit;
    
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

    private int gridLenght = 12;

    private void Start()
    {
        float frameScale = enigmaMazeCoreHuman._frameScale;
        InitStructMaze(firstMazeStruct, firstMazePattern, new Vector2(Screen.width /2 - gridLenght / 2 * frameScale, Screen.height / 2- gridLenght / 2 * frameScale) + Vector2.one * frameScale, 0.0f, _mazeWindRoses[0], "Maze");
        InitStructMaze(secondMazeStruct, secondMazePattern, new Vector2(Screen.width / 2 + gridLenght / 2 * frameScale, Screen.height / 2- gridLenght / 2 * frameScale) + new Vector2(-2f * frameScale, frameScale), -90f, _mazeWindRoses[1], "Maze");
        InitStructMaze(thirdMazeStruct, thirdMazePattern, new Vector2(Screen.width / 2 + gridLenght / 2 * frameScale, Screen.height / 2 + gridLenght / 2 * frameScale) + -Vector2.one * 2 * frameScale, 180f, _mazeWindRoses[2], "Maze");
        InitStructMaze(fourthMazeStruct, fourthMazePattern, new Vector2(Screen.width / 2 - gridLenght / 2 * frameScale, Screen.height / 2 + gridLenght / 2 * frameScale) + new Vector2(frameScale, -frameScale * 2), 90f, _mazeWindRoses[3], "Maze");
    }

    private void InitStructMaze(MazeStruct mazeStruct, int[,] mazePattern, Vector2 mazePawnBasePosition, float mazeRotation, GameObject mazeWindRose, string mazeLayer)
    {
        mazeStruct._mazePattern = mazePattern;
        mazeStruct._mazePawnBasePosition = mazePawnBasePosition;
        mazeStruct._mazeRotation = mazeRotation;
        mazeStruct._mazeWindRose = mazeWindRose;
        mazeStruct._mazeLayer = mazeLayer;

        if (enigmaMazeCoreHuman)
        {
            enigmaMazeCoreHuman._mazeStructures.Add(mazeStruct);
            enigmaMazeCoreHuman.DrawIfFull();
        }
        else if (enigmaMazeCoreSpirit)
        {
            enigmaMazeCoreSpirit._mazeStructures.Add(mazeStruct);
            enigmaMazeCoreSpirit.
                DrawIfFull();
        }
    }
    public int _maxPaternNumber = 4;
}
