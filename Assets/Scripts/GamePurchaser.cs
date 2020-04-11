using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GamePurchaser : MonoBehaviour {

    [Header("References for this panel")]
    public Button btnConfirmPurchase;
    public TextMeshProUGUI tmpCoinsBank;
    public TextMeshProUGUI tmpPriceTotal;
    public GameObject pnl_ThxPurchase;
    public GameObject pnl_NotEnoughCoins;
    public GameObject contentView;

    [Header("References for the confirmation panel")]
    public TextMeshProUGUI tmpPriceConfirmation;
    public TextMeshProUGUI tmpBankConfirmation;

    [HideInInspector]
    int intPriceTotal;

    /// <summary>
    /// Check if the total current price is greater than zero
    /// </summary>
    /// <returns></returns>
    public void TurnConfirmationBtnOnOff() {
         btnConfirmPurchase.interactable = (intPriceTotal > 0);
    }

    /// <summary>
    /// Update the displayed values when the panel is enabled
    /// </summary>
    private void OnEnable(){
        UpdateBankText();
    }

    /// <summary>
    /// Update the display of coins in the bank
    /// </summary>
    public void UpdateBankText() {
        tmpCoinsBank.text = CoinManager.instance.GetBank().ToString();
        tmpBankConfirmation.text = tmpCoinsBank.text;
    }

    /// <summary>
    /// Change the total price by adding an extra value
    /// </summary>
    /// <param name="addedValue"></param>
    public void ChangePriceTotal(int addedValue) {
        intPriceTotal += addedValue;
        tmpPriceTotal.text = "Total: " + intPriceTotal;
        tmpPriceConfirmation.text = intPriceTotal.ToString();
    }

    /// <summary>
    /// Spend coins and gain hammers if the purchase was successful
    /// </summary>
    public void ConfirmPurchase() {
        // Try to trade coins for hammers
        try {
            CoinManager coinManager = CoinManager.instance;
            coinManager.SaveCoinsToBank(-intPriceTotal); // may throw

            // Add the purchased items and reset purchase values
            GameProduct[] gameProducts = contentView.GetComponentsInChildren<GameProduct>();
            foreach (var gameProduct in gameProducts) {
                switch (gameProduct.product)
                {
                    case Product.HAMMER:
                        HammerManager.instance.PopulateHammerQueue(gameProduct.GetAmount());
                        break;
                    case Product.TEN_SEC:
                        IncreaseTimer(Product.TEN_SEC, gameProduct);
                        break;
                    case Product.TWENTY_SEC:
                        IncreaseTimer(Product.TWENTY_SEC, gameProduct);
                        break;
                    default:
                        break;
                }

                ResetValues(gameProduct, coinManager);
            }

            pnl_ThxPurchase.SetActive(true);
        } catch (System.InvalidOperationException ex) {
            pnl_NotEnoughCoins.SetActive(true);
            Debug.Log(ex.Message);
        }
    }

    /// <summary>
    /// Reset all panel values
    /// </summary>
    /// <param name="gameProduct"></param>
    /// <param name="coinManager"></param>
    void ResetValues(GameProduct gameProduct, CoinManager coinManager) {
        gameProduct.tmpProductAmount.text = "0";
        gameProduct.SetAmount(0);
        gameProduct.btnMinus.interactable = false;
        gameProduct.btnPlus.interactable = true;
        TurnConfirmationBtnOnOff();
        UpdateBankText();
        tmpPriceTotal.text = "Total: 0";
        tmpPriceConfirmation.text = intPriceTotal.ToString();
        coinManager.SaveCoinsToBank();
    }

    /// <summary>
    /// Increase the value of the timer by the value of time purchased
    /// </summary>
    /// <param name="product"></param>
    /// <param name="gameProduct"></param>
    void IncreaseTimer(Product product, GameProduct gameProduct) {
        TimerManager timerManager = TimerManager.instance;
        timerManager.SetTimer(timerManager.GetTimer() + (int)product * gameProduct.GetAmount());
    }
}
