using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class EnigmaMazeCoreHuman : MonoBehaviour
{
    public MazePattern _mazePattern;
    public EnigmaData _enigmaData;
    
    public List<MazeStruct> _mazeStructures = new();
    
    public GameObject _mazeFramePrefab;
    public Transform _mazeFrameStartPosition;
    
    [SerializeField] private float windScale;

    [SerializeField] private GameObject windRose;
    [SerializeField] private GameObject mazePawn;

    [SerializeField] private int frameScale;
    [SerializeField] private int gridLenght = 12;

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
        MazeStruct mazeStruct = _mazeStructures[Random.Range(0, _mazeStructures.Count)]; //takes a random maze between four patterns
        mazeGrid = mazeStruct._mazePattern; //gives to "mazeGrid" the list of int in mazeStruct
        
        for (int i = 0; i < gridLenght; i++)
        {
            for (int j = 0; j < gridLenght; j++)
            {
                // Set the position of each squares in the maze
                Vector2 mazeFramePos = new Vector2(
                    _mazeFrameStartPosition.position.x + i * frameScale,
                    _mazeFrameStartPosition.position.y + j * frameScale);

                //Instantiate the frame prefab at the position "mazeFramePos" and we put it in the gameObject "_mazeFrameStartPosition"
                GameObject mazeFrame = Instantiate(_mazeFramePrefab, mazeFramePos, Quaternion.identity, _mazeFrameStartPosition); 
            }
        }
        
        windRose = Instantiate(_mazeStructures[0]._mazeWindRose, new Vector2(gridLenght * windScale, gridLenght/windScale), Quaternion.identity);
        
        mazePawn = Instantiate(
            mazePawn,
            (Vector2)_mazeFrameStartPosition.position + mazeStruct._mazePawnBasePosition * frameScale,
            Quaternion.identity);
    }

    public void MovePawn(GameObject mazeFrame)
    {
        int x = (int)mazeFrame.transform.position.x / frameScale;
        int y = (int)mazeFrame.transform.position.y / frameScale;

        if (CheckForPawnSurroundings(x, y))
        {
            if (mazeGrid[x, y] == 1)
            {
                ResetMaze();
                return;
            } 
            
            if (mazeGrid[x, y] == 2)
            {
                Win();
                return;
            }
                
            mazePawn.transform.position = new Vector2(x * frameScale, y * frameScale);
        }
    }

    private bool CheckForPawnSurroundings(int x, int y)
    {
        if (x == (int)mazePawn.transform.position.x && y == (int)mazePawn.transform.position.y + 1
            || x == (int)mazePawn.transform.position.x && y == (int)mazePawn.transform.position.y - 1
            || x == (int)mazePawn.transform.position.x - 1 && y == (int)mazePawn.transform.position.y
            || x == (int)mazePawn.transform.position.x + 1 && y == (int)mazePawn.transform.position.y)
            return true;

        else return false;
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
        Debug.Log("Lose");
    }

    private void Win()
    {
        this.enabled = false;
        Debug.Log("Win");
    }
}
