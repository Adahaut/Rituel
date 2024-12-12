using UnityEngine;

public class AutoOrderInLayer : MonoBehaviour
{
    private void Awake()
    {
        SetOrderInLayer();
    }

    public void SetOrderInLayer()
    {
        var particleRenderer = GetComponent<Renderer>();
        particleRenderer.sortingOrder = transform.GetOrderInLayer();
    }
}
