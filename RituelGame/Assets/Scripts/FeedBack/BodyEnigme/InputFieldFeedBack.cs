using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputFieldFeedBack : MonoBehaviour
{
    public TextMeshProUGUI textPlaecHolder;

    public void HideSelect()
    {
        textPlaecHolder.text = "";
    }

    public void ShowSelect()
    {
        textPlaecHolder.text = "Name ...";
    }
}
