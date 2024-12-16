using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCandle : MonoBehaviour
{
    public Sprite _lightedCandle;

    public void LightCandle()
    {
        gameObject.GetComponent<Image>().sprite = _lightedCandle;
    }
}
