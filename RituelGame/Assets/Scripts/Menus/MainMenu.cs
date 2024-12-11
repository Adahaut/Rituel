using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject _startCanvas;
    public GameObject _optionCanvas;
    public GameObject _selectCharacterCanvas;
    
    private GameObject lastCanvasOpen;
    private GameObject actualCanvas;

    [SerializeField]
    private GameObject light;
    private Camera cam;
    Vector3 mousePosition;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        FollowCursorLight();
    }

    private void FollowCursorLight()
    {
        mousePosition = Input.mousePosition;
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        light.transform.position = new Vector3(mousePosition.x, mousePosition.y, 1);
    }
    public void StartGame()
    {
        _startCanvas.SetActive(false);
        _selectCharacterCanvas.SetActive(true);

        actualCanvas = _selectCharacterCanvas;
        lastCanvasOpen = _startCanvas;
    }

    public void StartAsHuman(string firstSceneHuman)
    {
        SceneManager.LoadScene(firstSceneHuman);
    }
    
    public void StartAsSpirit(string firstSceneSpirit)
    {
        SceneManager.LoadScene(firstSceneSpirit);
    }
    
    public void Option()
    {
        _startCanvas.SetActive(false);
        _optionCanvas.SetActive(true);

        actualCanvas = _optionCanvas;
        lastCanvasOpen = _startCanvas;
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        actualCanvas.SetActive(false);
        lastCanvasOpen.SetActive(true);
    }
}
