using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpiritController : MonoBehaviour
{
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
                GameObject maze = hit.collider.gameObject.transform.parent.gameObject;
                maze.transform.position = Vector2.zero;
                
                maze.transform.localScale = new Vector3(2, 2, 2);
            }
        }
    }
}
