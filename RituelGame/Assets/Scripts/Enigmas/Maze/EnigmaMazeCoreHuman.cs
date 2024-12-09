using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnigmaMazeCoreHuman : MonoBehaviour
{
    public GameObject _maze;
    public GameObject _code;
    
    public MazePattern _mazePattern;
    public EnigmaData _enigmaData;
    public LinkCore _linkCore;

    public List<MazeStruct> _mazeStructures = new();

    public GameObject _mazeFramePrefab;
    public Transform _mazeFrameStartPosition;

    [SerializeField] private Vector2 windScale;

    [SerializeField] private GameObject windRose;
    [SerializeField] private GameObject mazePawnPrefab;
    private GameObject mazePawn;

    [SerializeField] private float frameScale;
    [SerializeField] private int gridLenght = 12;
    [SerializeField] private LinkCore linkCore;

    private int[,] mazeGrid;

    public void DrawIfFull()
    {
        if (_mazeStructures.Count == _mazePattern._maxPaternNumber)
        {
            DrawMaze();
        }
    }

    private void DrawMaze()
    {
        MazeStruct
            mazeStruct =
                _mazeStructures[Random.Range(0, _mazeStructures.Count)]; //takes a random maze between four patterns
        mazeGrid = mazeStruct._mazePattern; //gives to "mazeGrid" the list of int in mazeStruct

        for (int i = 0; i < gridLenght; i++)
        {
            for (int j = 0; j < gridLenght; j++)
            {
                // Set the position of each squares in the maze
                Vector2 mazeFramePos = new Vector2(
                    (i * frameScale) + (Screen.width / 2 - gridLenght / 2 * frameScale),
                    ((j * frameScale) + (Screen.height / 2 - gridLenght / 2 * frameScale)));

                //Instantiate the frame prefab at the position "mazeFramePos" and we put it in the gameObject "_mazeFrameStartPosition"
                GameObject mazeFrame = Instantiate(_mazeFramePrefab, mazeFramePos, Quaternion.identity,
                    _mazeFrameStartPosition);
                mazeFrame.GetComponent<RectTransform>().sizeDelta = Vector2.one * frameScale;
            }
        }

        windRose = Instantiate(_mazeStructures[0]._mazeWindRose, Vector3.zero, Quaternion.identity);
        windRose.transform.SetParent(transform);
        windRose.transform.position = new Vector2((Screen.width / 2) + (gridLenght * frameScale / 2 + windScale.x),
            Screen.height / 2);

        mazePawn = Instantiate(
            mazePawnPrefab,
            (Vector2)mazeStruct._mazePawnBasePosition,
            Quaternion.identity);
        mazePawn.transform.SetParent(transform);
    }

    public void MovePawn(GameObject mazeFrame)
    {
        int x = Mathf.RoundToInt((mazeFrame.transform.position.x - (Screen.width / 2 - gridLenght / 2 * frameScale)) /
                                 frameScale);
        int y = Mathf.RoundToInt((mazeFrame.transform.position.y - (Screen.height / 2 - gridLenght / 2 * frameScale)) /
                                 frameScale);


        if (CheckForPawnSurroundings(x, y, mazeFrame.transform))
        {
            mazePawn.transform.position = new Vector2(mazeFrame.transform.position.x, mazeFrame.transform.position.y);
        }
    }

    private bool CheckForPawnSurroundings(int x, int y, Transform mazeFrame)
    {
        Vector2 casePos = new Vector2(x, y);
        if (Vector2.Distance(mazeFrame.position, mazePawn.transform.position) <= frameScale)
        {
            if (mazeGrid[x, y] == 0)
            {
                return true;
            }
            else if (mazeGrid[x, y] == 1)
            {
                ResetMaze();
                return false;
            }
            else if (mazeGrid[x, y] == 2)
            {
                Win();
            }
        }

        return false;
    }

    private void ResetMaze()
    {
        foreach (Transform child in _mazeFrameStartPosition)
        {
            Destroy(child.gameObject);
        }

        Destroy(mazePawn);
        Destroy(windRose);
        DrawMaze();
    }

    private void Lose()
    {
        _linkCore.RemoveLink(_enigmaData.LinkToRemoveIfFail);
    }

    public void Win()
    {
        _linkCore.AddLink(_enigmaData.LinkToAddIfSuccess);
        _enigmaData.GetReward();
        _maze.SetActive(false);
        _code.SetActive(true);
    }
}