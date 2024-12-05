using UnityEngine;

public static class CanvasGroupExtensions
{
    public static void ActivateCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        SetCanvasGroupInteraction(canvasGroup, true);
    }

    public static void DeactivateCanvasGroup(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        SetCanvasGroupInteraction(canvasGroup, false);
    }
    
    public static void SetCanvasGroupInteraction(this CanvasGroup canvasGroup, bool activated)
    {
        canvasGroup.interactable = activated;
        canvasGroup.blocksRaycasts = activated;
    }
}
