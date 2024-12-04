using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class EnigmaMazeCoreHuman : MonoBehaviour
{
    public MazePaterns _mazePaterns;
    
    public GameObject _mazeFramePrefab;
    public Transform _mazeFrameStartPosition;

    private int[,] mazeArray;

    [SerializeField] private GameObject windRose;
    [SerializeField] private float windScale;

    [SerializeField] private GameObject mazePawn;
    [SerializeField] private Vector2 spawnPawnPosition;

    [SerializeField] private int frameScale;
    [SerializeField] private int gridLenght = 12;
    
    [SerializeField] private int connectionLoss;
    
    
    private void Start()
    {
        mazeArray = _mazePaterns.Paterns();
        spawnPawnPosition = _mazePaterns.SetPawnBasePosition();
        DrawMaze();
    }
    private void DrawMaze()
    {
        for (int i = 0; i < gridLenght; i++)
        {
            for (int j = 0; j < gridLenght; j++)
            {
                Vector2 mazeFramePos = new Vector2(
                    _mazeFrameStartPosition.position.x + i * frameScale,
                    _mazeFrameStartPosition.position.y + j * frameScale);

                GameObject mazeFrame = Instantiate(_mazeFramePrefab, mazeFramePos, Quaternion.identity, _mazeFrameStartPosition); 
            }
        }
        
        windRose = Instantiate(windRose, new Vector2(gridLenght * windScale, gridLenght/windScale), Quaternion.identity);
        
        mazePawn = Instantiate(
            mazePawn,
            (Vector2)_mazeFrameStartPosition.position + spawnPawnPosition * frameScale,
            Quaternion.identity);
    }

    public void MovePawn(GameObject mazeFrame)
    {
        int x = (int)mazeFrame.transform.position.x / frameScale;
        int y = (int)mazeFrame.transform.position.y / frameScale;

        if (CheckForPawnSurroundings(x, y))
        {
            if (mazeArray[x, y] == 1)
            {
                ResetMaze();
                return;
            } else if (mazeArray[x, y] == 2)
                Win();
                
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
        spawnPawnPosition = _mazePaterns.SetPawnBasePosition();
        mazeArray = _mazePaterns.Paterns();
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
