using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

/// <summary>
/// Control how in-game products are purchased with in-game currency
/// </summary>
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
    GameProduct[] gameProducts;

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
        gameProducts = contentView.GetComponentsInChildren<GameProduct>();
        ResetValues(gameProducts);
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
        tmpPriceTotal.text = intPriceTotal.ToString();
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
            foreach (var gameProduct in gameProducts) {
                switch (gameProduct.product) {
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

                ResetValues(gameProduct);
                coinManager.SaveBankAndHammers();
            }

            UpdateBankText();
            pnl_ThxPurchase.SetActive(true);
        } catch (System.InvalidOperationException ex) {
            pnl_NotEnoughCoins.SetActive(true);
            Debug.Log(ex.Message);
        }
    }

    /// <summary>
    /// Reset product panel values
    /// </summary>
    /// <param name="gameProduct"></param>
    /// <param name="coinManager"></param>
    void ResetValues(GameProduct gameProduct) {
        gameProduct.tmpProductAmount.text = "0";
        gameProduct.SetAmount(0);
        gameProduct.btnMinus.interactable = false;
        gameProduct.btnPlus.interactable = true;
        TurnConfirmationBtnOnOff();
        intPriceTotal = 0;
        tmpPriceTotal.text = "0";
    }

    /// <summary>
    /// Reset values of all product panels
    /// </summary>
    /// <param name="gameProducts"></param>
    /// <param name="coinManager"></param>
    void ResetValues(GameProduct[] gameProducts) { 
        foreach (var gameProduct in gameProducts) {
            ResetValues(gameProduct);
        }
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
