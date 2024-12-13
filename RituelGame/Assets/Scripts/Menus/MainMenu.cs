using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject _startCanvas;
    public GameObject _optionCanvas;
    public GameObject _selectCharacterCanvas;
    public GameObject _selectDifficultyCanvas;
    
    private GameObject lastCanvasOpen;
    private GameObject actualCanvas;

    [SerializeField]
    private GameObject light;

    private Camera cam;

    public string _cinematicScene;
    
    private void Start()
    {
        cam = Camera.main;
        Texture2D candleCursor = Resources.Load<Texture2D>("CandleCursor");
        Cursor.SetCursor(candleCursor, Vector2.zero, CursorMode.Auto);
        
        if (PlayerPrefs.GetInt("CinematicDone") == 1)
        {
            StartGame();
        }
    }

    private void Update()
    {
        if (light)
        {
            FollowCursorLight();   
        }
    }

    private void FollowCursorLight()
    {
        Vector3 mousePos = Input.mousePosition; 
        mousePos.z = 10f;
        Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        light.transform.position = worldPos;
    }
    public void StartGame()
    {
        if (PlayerPrefs.GetInt("CinematicDone") == 1)
        {
            _startCanvas.SetActive(false);
            _selectDifficultyCanvas.SetActive(true);

            actualCanvas = _selectDifficultyCanvas;
            lastCanvasOpen = _startCanvas;
        }
        else
        {
            PlayerPrefs.SetInt("CinematicDone", 1);
            SceneManager.LoadScene(_cinematicScene);
        }
    }

    public void StartAsHuman(string firstSceneHuman)
    {
        PlayerPrefs.SetInt("CinematicDone", 0);
        SceneManager.LoadScene(firstSceneHuman);
    }
    
    public void StartAsSpirit(string firstSceneSpirit)
    {
        PlayerPrefs.SetInt("CinematicDone", 0);
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
