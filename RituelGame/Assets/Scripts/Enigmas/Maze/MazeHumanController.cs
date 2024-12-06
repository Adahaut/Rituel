using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MazeHumanController : MonoBehaviour, AllInterafce.IEnigmaCore
{
    public EnigmaMazeCoreHuman maze;
    
    private Camera cam;

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
        

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.gameObject)
            {
                maze.MovePawn(hit.gameObject);
            }
        }
    }

    [field:SerializeField]
    public EnigmaType _enigmaType { get; set; }
    [field:SerializeField]
    public GameObject _unlockButtonThisEnigma { get; set; }
    public void UnlockNextEnigme()
    {
        if (_unlockButtonThisEnigma)
        {
            _unlockButtonThisEnigma.SetActive(true);   
        }
    }
}
