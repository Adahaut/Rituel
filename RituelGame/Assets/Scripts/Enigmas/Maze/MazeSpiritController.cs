using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpiritController : MonoBehaviour
{
    private Camera cam;
    public GameObject _panel;
    
    private GameObject maze;
    private Vector3 mazeBasePos;

    private bool zoomed;
    
    Vector3 midPos = new Vector2(18f, 3.75f);
    
    private void Start()
    {
        cam = Camera.main;
    }
    
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButton(0))
        {
            if (hit) //up scaling the maze and placing it in the middle of the screen in order to choose which maze is the more suitable.
            {
                maze = hit.collider.gameObject.transform.parent.gameObject;
                if(zoomed  == false)
                    mazeBasePos = maze.transform.position;
                
                zoomed = true;
                maze.transform.position = midPos;
                maze.transform.localScale = new Vector3(2, 2, 2);
                
                maze.transform.position += ReplaceMaze(hit.collider.gameObject.layer);
                _panel.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) //Replacing the maze in his original position
        {
            _panel.SetActive(false);
            zoomed = false;
            maze.transform.position = mazeBasePos;
            
            maze.transform.localScale = Vector3.one;
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
