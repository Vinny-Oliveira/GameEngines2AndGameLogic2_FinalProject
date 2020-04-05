﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using TMPro;

/// <summary>
/// Control the IAP of the game - how the player trades coins for hammers and extra time
/// </summary>
public class PurchaseController : MonoBehaviour {

    [Header("UI References")]
    public IAPButton iapButton;
    public Button stdButton;
    public GameObject gameOverPurchaseBtn;
    public GameObject gameOverContinueBtn;
    public TextMeshProUGUI tmpProductAmount;
    public GameObject thxPurchasePanel;
    
    [Header("Cost and Product")]
    public int cost;
    public int productAmount;

    const int MIN_TIMER = 10;

    /// <summary>
    /// Spend coins and gain hammers if the purchase was successful
    /// </summary>
    public void ConfirmPurchase() {
        if (iapButton == null) {
            iapButton = GetComponent<IAPButton>();
        }

        // Trade coins for hammers
        CoinManager.instance.SaveCoinsToBank(-cost);
        HammerManager hammerManager = HammerManager.instance;
        hammerManager.PopulateHammerQueue(productAmount);

        // Give the user some more time if they are running short
        TimerManager timerManager = TimerManager.instance;
        if (timerManager.GetTimer() < MIN_TIMER) {
            timerManager.SetTimer(MIN_TIMER);
        }

        // Reset UI objects
        tmpProductAmount.text = productAmount.ToString();
        thxPurchasePanel.SetActive(true);
        gameOverPurchaseBtn.SetActive(false);
        gameOverContinueBtn.SetActive(true);
        TurnButtonOnOff();
    }

    /// <summary>
    /// Check if the button should be interactable.
    /// It should be only if the cost of the product is less than what the player has.
    /// </summary>
    void TurnButtonOnOff() {
        if (stdButton == null) {
            stdButton = GetComponent<Button>();
        }

        stdButton.interactable = (cost <= CoinManager.instance.GetBank());
    }

    /// <summary>
    /// Check if the button should be interactable when it awakes
    /// </summary>
    private void OnEnable() {
        TurnButtonOnOff();
    }
}