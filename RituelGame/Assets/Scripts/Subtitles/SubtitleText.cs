using TMPro;
using UnityEngine;

public class SubtitleText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI subtitleText = default;
    
    public static SubtitleText _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void SetSubtitle(string subtitle)
    {
        subtitleText.text = subtitle;
    }
}
