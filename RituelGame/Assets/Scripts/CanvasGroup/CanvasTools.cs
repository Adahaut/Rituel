using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CanvasTools
{
    public static int GetOrderInLayer(this Transform transform)
    {
        var canvasComponent = transform.GetComponentInParent<Canvas>();
        if (canvasComponent.isRootCanvas || canvasComponent.overrideSorting)
        {
            return canvasComponent.sortingOrder;
        }

        return GetOrderInLayer(transform.parent);
    }
}
