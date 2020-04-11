using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IAP_Controller : MonoBehaviour {

    [Header("UI References")]
    public TextMeshProUGUI tmp_Total_Coins;
    public TextMeshProUGUI tmpAmount;
    public TextMeshProUGUI tmpCost;
    
    [Header("Product Details")]
    public int intAmount;
    public float intCost;

    /// <summary>
    /// When the panel is enabled, display the 
    /// </summary>
    private void OnEnable() {
        tmpAmount.text = intAmount.ToString();
        tmpCost.text = intCost.ToString("c2");
    }

    /// <summary>
    /// Save the purchased coins to the bank
    /// </summary>
    public void SavePurchasedCoins() {
        try {
            CoinManager coinManager = CoinManager.instance;
            coinManager.SaveCoinsToBank(intAmount);
            tmp_Total_Coins.text = coinManager.GetBank().ToString();
        } catch (System.InvalidOperationException ex) {
            Debug.LogError(ex.Message);
        }
    }
}
