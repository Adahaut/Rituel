using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCandle : MonoBehaviour
{
    public Sprite _unLightCandle;
    public Sprite _lightedCandle;

    public void LightCandle()
    {
        gameObject.GetComponent<Image>().sprite = _lightedCandle;
        gameObject.GetComponent<AnimeCandle>().StartAnime();
    }

    public void UnLightCandle()
    {
        gameObject.GetComponent<AnimeCandle>().StopAnime();
        gameObject.GetComponent<Image>().sprite = _unLightCandle;
    }
}
