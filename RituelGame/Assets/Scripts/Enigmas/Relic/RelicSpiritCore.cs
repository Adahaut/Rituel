using System;
using Enigmas;
using Enigmas.EnigmaHint;
using UnityEngine;
using UnityEngine.Serialization;

public class RelicSpiritCore : MonoBehaviour
{
    [SerializeField] private CanvasGroup closedChest;
    [SerializeField] private CanvasGroup openedChest;
    [SerializeField] private float chestInteractionCooldown;
    private float chestCooldownTimer;
    [SerializeField] private AudioManager audioManager;

    public GameObject _hint;
    public GameObject _hint2;
    public GameObject _button;

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
        
        _hint2.SetActive(true);
        
        _button.GetComponent<EnigmaButton>()._onButtonClicked.AddListener(_hint.GetComponent<EnigmaHintButton>().Activate);
        _hint.SetActive(false);
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
        _button.GetComponent<EnigmaButton>()._onButtonClicked.RemoveListener(_hint.GetComponent<EnigmaHintButton>().Activate);
        _hint.SetActive(true);
        _hint2.SetActive(false);
    }
}
