using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MazeSpiritController : MonoBehaviour
{
    private Camera cam;
    public EnigmaMazeCoreSpirit _enigmaCoreSpirit;
    public GameObject _panel;
    
    private GameObject maze;
    private Vector3 mazeBasePos;
    private Vector2 initScale;

    private bool zoomed;
    
    Vector3 midPos = new Vector2(18f, 3.75f);
    
    private void Start()
    {
        cam = Camera.main;
    }
    
    void Update()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        RaycastResult hit = results.Find(r => r.gameObject.GetComponent<CanvasRenderer>());

        if (Input.GetMouseButton(0))
        {
            if (!hit.gameObject) //up scaling the maze and placing it in the middle of the screen in order to choose which maze is the more suitable.
            {
                return;
            }
            
            if (hit.gameObject.layer != LayerMask.NameToLayer("Maze"))
            {
                return;
            }

            maze = hit.gameObject.transform.parent.gameObject;

            Canvas mazeCanvas = maze.transform.parent.GetComponent<Canvas>();
            mazeCanvas.overrideSorting = true;
            mazeCanvas.sortingOrder = 2;

            if (zoomed == false)
            {
                mazeBasePos = maze.transform.position;
                initScale = maze.transform.localScale;
            }

            zoomed = true;
            maze.transform.position = transform.position;
            maze.transform.localScale = new Vector3(2, 2, 2);

            //maze.transform.position += ReplaceMaze(hit.gameObject.layer) * _enigmaCoreSpirit._frameScale;
            _panel.SetActive(true);
            Debug.Log(initScale);
        }

        if (Input.GetKeyDown(KeyCode.Space)) //Replacing the maze in his original position
        {
            _panel.SetActive(false);
            zoomed = false;
            maze.transform.position = mazeBasePos;
            
            maze.transform.localScale = initScale;
            
            Canvas mazeCanvas = maze.transform.parent.GetComponent<Canvas>();
            mazeCanvas.overrideSorting = false;
            mazeCanvas.sortingOrder = 0;
        }
    }

    private Vector3 ReplaceMaze(LayerMask mazeLayer) //Replacing the maze after zooming in order to place it in the middle
    {
        if (mazeLayer == LayerMask.NameToLayer("FirstMaze"))
        {
            return new Vector3(-12f, -12f, -2f);
        }
        if (mazeLayer == LayerMask.NameToLayer("SecondMaze"))
        {
            return new Vector3(-12f, 12f, -2f);
        }
        if (mazeLayer == LayerMask.NameToLayer("ThirdMaze"))
        {
            return new Vector3(12f, 12f, -2f);
        }
        if (mazeLayer == LayerMask.NameToLayer("FourthMaze"))
        {
            return new Vector3(12f, -12f, -2f);
        }
        
        return Vector3.zero;
    }
}
