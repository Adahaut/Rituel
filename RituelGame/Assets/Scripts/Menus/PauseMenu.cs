using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject _pauseCanvas;

    public void PauseManuCanvas(InputAction.CallbackContext ctx)
    {
        _pauseCanvas.SetActive(!_pauseCanvas.activeSelf);
    }
}
