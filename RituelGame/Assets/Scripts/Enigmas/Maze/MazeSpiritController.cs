using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpiritController : MonoBehaviour
{
    private Camera cam;
    public GameObject Panel;
    
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
            if (hit)
            {
                maze = hit.collider.gameObject.transform.parent.gameObject;
                if(zoomed  == false)
                    mazeBasePos = maze.transform.position;
                
                Debug.Log(mazeBasePos);
                zoomed = true;
                maze.transform.position = midPos;
                maze.transform.localScale = new Vector3(2, 2, 2);
                Debug.Log(hit.collider.gameObject.layer);
                
                maze.transform.position += ReplaceMaze(hit.collider.gameObject.layer);
                Panel.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Panel.SetActive(false);
            zoomed = false;
            maze.transform.position = mazeBasePos;
            
            maze.transform.localScale = Vector3.one;
        }
    }

    private Vector3 ReplaceMaze(LayerMask mazeLayer)
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
