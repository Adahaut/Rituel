using System;
using UnityEngine;
using UnityEngine.Serialization;

public class RelicSpiritCore : MonoBehaviour
{
    [SerializeField] private CanvasGroup closedChest;
    [SerializeField] private CanvasGroup openedChest;
    [SerializeField] private float chestInteractionCooldown;
    private float chestCooldownTimer;
    [SerializeField] private AudioManager audioManager;

    private void Update()
    {
        ChestInteractionTimer();
    }

    private void ChestInteractionTimer()
    {
        if (chestCooldownTimer <= 0)
        {
            return;
        }

        chestCooldownTimer -= Time.deltaTime;
    }

    public void OpenChest()
    {
        audioManager.PlayOverlap("OpenChest");
        if (chestCooldownTimer > 0)
        {
            return;
        }
        openedChest.ActivateCanvasGroup();
        closedChest.DeactivateCanvasGroup();
        chestCooldownTimer = chestInteractionCooldown;
    }

    public void CloseChest()
    {
        audioManager.PlayOverlap("CloseChest");
        if (chestCooldownTimer > 0)
        {
            return;
        }
        openedChest.DeactivateCanvasGroup();
        closedChest.ActivateCanvasGroup();
        chestCooldownTimer = chestInteractionCooldown;
    }
}
