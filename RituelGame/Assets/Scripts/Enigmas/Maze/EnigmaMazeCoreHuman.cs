using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Enigmas.Maze;

using Enigmas;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

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

    public float _frameScale;
    [SerializeField] private int gridLenght = 12;
    public Canvas _canvasParent;
    public GameObject _buttonToAccessEnigma;

    private int[,] mazeGrid;

    private Dictionary<Vector2Int, GameObject> mazeFrames = new();
    private Vector2Int pawnPos;
    
    [SerializeField] private AudioManager audioManager;
    
    public UnityEvent _onEnigmaFinished;
    


    public void DrawIfFull()
    {
        if (_mazeStructures.Count == _mazePattern._maxPaternNumber)
        {
            _canvasParent.renderMode = RenderMode.ScreenSpaceOverlay;
            DrawMaze();
            _canvasParent.renderMode = RenderMode.ScreenSpaceCamera;
        }
    }

    private void DrawMaze()
    {
        MazeStruct
            mazeStruct =
                _mazeStructures[Random.Range(0, _mazeStructures.Count)]; //takes a random maze between four patterns
        mazeGrid = mazeStruct._mazePattern; //gives to "mazeGrid" the list of int in mazeStruct

        mazeFrames.Clear();
        for (int i = 0; i < gridLenght; i++)
        {
            for (int j = 0; j < gridLenght; j++)
            {
                // Set the position of each squares in the maze
                Vector2 mazeFramePos = new Vector2(
                    (i * _frameScale) + (Screen.width / 2 - gridLenght / 2 * _frameScale),
                    ((j * _frameScale) + (Screen.height / 2 - gridLenght / 2 * _frameScale)));

                //Instantiate the frame prefab at the position "mazeFramePos" and we put it in the gameObject "_mazeFrameStartPosition"
                GameObject mazeFrame = Instantiate(_mazeFramePrefab, mazeFramePos, Quaternion.identity,
                    _mazeFrameStartPosition);
                mazeFrame.GetComponent<RectTransform>().sizeDelta = Vector2.one * _frameScale;
                mazeFrame.GetComponent<MazeTile>().OnTileClickedEvent += MovePawn;
                mazeFrames.Add(new Vector2Int(i, j), mazeFrame);
            }
        }

        windRose = Instantiate(_mazeStructures[0]._mazeWindRose, Vector3.zero, Quaternion.identity);
        windRose.transform.SetParent(transform);
        windRose.transform.position = new Vector2((Screen.width / 2) + (gridLenght * _frameScale / 2 + windScale.x),
            Screen.height / 2);

        mazePawn = Instantiate(
            mazePawnPrefab,
            mazeFrames[mazeStruct._mazePawnBasePosition].transform.position,
            Quaternion.identity);
        mazePawn.transform.SetParent(transform);
        pawnPos = mazeStruct._mazePawnBasePosition;
    }

    public void MovePawn(GameObject clickedObject)
    {
        List<GameObject> mazeFramesValues = mazeFrames.Values.ToList();
        if (!mazeFramesValues.Contains(clickedObject))
        {
            return;
        }
        int indexFrame = mazeFramesValues.IndexOf(clickedObject);
        Vector2Int mazeArrayPos = mazeFrames.Keys.ToList()[indexFrame];
        
        int x = Mathf.RoundToInt((clickedObject.transform.position.x - (Screen.width / 2 - gridLenght / 2 * _frameScale)) /
                                 _frameScale);
        int y = Mathf.RoundToInt((clickedObject.transform.position.y - (Screen.height / 2 - gridLenght / 2 * _frameScale)) /
                                 _frameScale);

        
        if (CheckForPawnSurroundings(mazeArrayPos.x, mazeArrayPos.y, clickedObject.transform))
        {
            mazePawn.transform.DOMove(new Vector2(clickedObject.transform.position.x, clickedObject.transform.position.y), 0.5f);
            pawnPos = mazeArrayPos;
            audioManager.PlayOverlap("MazeMove");
        }
    }

    private bool CheckForPawnSurroundings(int x, int y, Transform mazeFrame)
    {
        Vector2 casePos = new Vector2(x, y);
        if (Vector2.Distance(casePos, pawnPos) <= 1)
        {
            if (mazeGrid[x, y] == 0 || mazeGrid[x, y] == 3)
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
        _canvasParent.renderMode = RenderMode.ScreenSpaceOverlay;
        DrawMaze();
        _canvasParent.renderMode = RenderMode.ScreenSpaceCamera;

        Lose();
    }

    private void Lose()
    {
        _linkCore.RemoveLink(_enigmaData.LinkToRemoveIfFail);
    }

    public void Win()
    {
        _buttonToAccessEnigma.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f);
        _buttonToAccessEnigma.GetComponent<EnigmaButton>()._enigmaFinish = true;
        _linkCore.AddLink(_enigmaData.LinkToAddIfSuccess);
        _enigmaData.GetReward();
        _onEnigmaFinished.Invoke();
        _maze.SetActive(false);
        _code.SetActive(true);
    }
}