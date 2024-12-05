using System;
using UnityEngine;
using UnityEngine.Serialization;

public class RelicSpiritCore : MonoBehaviour
{
    [SerializeField] private CanvasGroup closedChest;
    [SerializeField] private CanvasGroup openedChest;
    [SerializeField] private float chestInteractionCooldown;
    private float chestCooldownTimer;

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
        if (chestCooldownTimer > 0)
        {
            return;
        }
        openedChest.DeactivateCanvasGroup();
        closedChest.ActivateCanvasGroup();
        chestCooldownTimer = chestInteractionCooldown;
    }
}
