using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InGamePurchaser : MonoBehaviour {


    public Button btnConfirmPurchase;
    public TextMeshProUGUI tmpPriceTotal;
    public GameObject pnl_ThxPurchase;
    public GameObject pnl_NotEnoughCoins;
    public GameObject contentView;
    
    [HideInInspector]
    public int intPriceTotal;
    
    //[Header("Cost and Product")]
    //public int cost;
    //public int productAmount;

    //const int MIN_TIMER = 10;

    /// <summary>
    /// Spend coins and gain hammers if the purchase was successful
    /// </summary>
    public void ConfirmPurchase() {
        // Try to trade coins for hammers
        try {
            CoinManager.instance.SaveCoinsToBank(-intPriceTotal); // may throw

            // Add the purchased items and reset purchase values
            InGameProductDisplayer[] inGameProducts = contentView.GetComponentsInChildren<InGameProductDisplayer>();
            foreach (var gameProduct in inGameProducts) {
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

                gameProduct.tmpProductAmount.text = "0";
                gameProduct.SetAmount(0);
                gameProduct.btnMinus.interactable = false;
                gameProduct.btnPlus.interactable = true;
            }

            pnl_ThxPurchase.SetActive(true);
        } catch (System.InvalidOperationException ex) {
            pnl_NotEnoughCoins.SetActive(true);
            Debug.Log(ex.Message);
        }
    }

    /// <summary>
    /// Increase the value of the timer by the value of time purchased
    /// </summary>
    /// <param name="product"></param>
    /// <param name="gameProduct"></param>
    void IncreaseTimer(Product product, InGameProductDisplayer gameProduct) {
        TimerManager timerManager = TimerManager.instance;
        timerManager.SetTimer(timerManager.GetTimer() + (int)product * gameProduct.GetAmount());
    }
}
