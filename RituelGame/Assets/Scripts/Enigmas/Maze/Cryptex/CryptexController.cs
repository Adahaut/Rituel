using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CryptexController : MonoBehaviour
{
    private Camera cam;
    
    public CryptexCircles _cryptexCircle;
    public CryptexRotation _cryptexRotation;

    private int direction;

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
                if (hit.collider.gameObject.transform.parent.gameObject == this.gameObject)
                {
                    direction = hit.collider.gameObject.GetComponent<CryptexLinkedCollider>().direction;
                    Debug.Log("hit");

                    if (direction > 0)
                    {
                        _cryptexCircle.IncrementValue();
                        _cryptexRotation.Rotating();
                    }

                    else if (direction < 0)
                    {
                        _cryptexCircle.DecrementValue();
                        _cryptexRotation.Rotating();
                    }
                }
            }
        }
    }
}
