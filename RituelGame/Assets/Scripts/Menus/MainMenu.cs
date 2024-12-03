using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject _startCanvas;
    public GameObject _optionCanvas;
    public GameObject _selectCharacterCanvas;
    
    private GameObject lastCanvasOpen;
    private GameObject actualCanvas;

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
