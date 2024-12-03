using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    public EnigmaMazeCoreHuman maze;
    
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit)
            {
                GameObject mazeFrame = hit.collider.gameObject;
                maze.MovePawn(mazeFrame);
            }
        }
    }
}
