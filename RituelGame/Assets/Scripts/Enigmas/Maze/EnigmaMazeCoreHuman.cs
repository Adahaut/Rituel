using System.Collections.Generic;
using UnityEngine;

public class EnigmaMazeCoreHuman : MonoBehaviour
{
    public MazePattern _mazePattern;
    public EnigmaData _enigmaData;
    
    public List<MazeStruct> _mazeStructures = new();
    
    public GameObject _mazeFramePrefab;
    public Transform _mazeFrameStartPosition;
    
    [SerializeField] private Vector2 windScale;

    [SerializeField] private GameObject windRose;
    [SerializeField] private GameObject mazePawnPrefab;
    private GameObject mazePawn;

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
                mazeFrame.GetComponent<RectTransform>().sizeDelta = Vector2.one * frameScale;
            }
        }
        
        windRose = Instantiate(_mazeStructures[0]._mazeWindRose, Vector3.zero, Quaternion.identity);
        windRose.transform.SetParent(transform);
        windRose.transform.position = windScale * gridLenght;
        
        mazePawn = Instantiate(
            mazePawnPrefab,
            (Vector2)_mazeFrameStartPosition.position + mazeStruct._mazePawnBasePosition * frameScale,
            Quaternion.identity);
        mazePawn.transform.SetParent(transform);
    }

    public void MovePawn(GameObject mazeFrame)
    {
        int x = Mathf.RoundToInt((mazeFrame.transform.position.x - _mazeFrameStartPosition.position.x) / frameScale);
        int y = Mathf.RoundToInt((mazeFrame.transform.position.y - _mazeFrameStartPosition.position.y) / frameScale);

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
                
            mazePawn.transform.position = new Vector2(mazeFrame.transform.position.x, mazeFrame.transform.position.y);
        }
    }

    private bool CheckForPawnSurroundings(int x, int y)
    {
        int positionX = Mathf.RoundToInt((mazePawn.transform.position.x - _mazeFrameStartPosition.position.x) / frameScale);
        int positionY = Mathf.RoundToInt((mazePawn.transform.position.y - _mazeFrameStartPosition.position.y) / frameScale);
        if (x == positionX && y == positionY + 1
            || x == positionX && y == positionY - 1
            || x == positionX - 1 && y == positionY
            || x == positionX + 1 && y == positionY)
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
