using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CryptexController : MonoBehaviour
{
    private Camera cam;
    
    void Start()
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
                hit.collider.gameObject.GetComponent<CryptexLinkedCollider>().Rotation();
            }
        }
    }
}
