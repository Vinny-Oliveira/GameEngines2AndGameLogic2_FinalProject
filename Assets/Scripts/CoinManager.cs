using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : SingletonManager<CoinManager> {

    // Count of the player's coins
    int intCoins;
    const int START_COINS = 0;

    // UI References
    public TextMeshProUGUI tmpCoins;

    private void Start() {
        intCoins = START_COINS;
    }

    /// <summary>
    /// Get the total number of coins
    /// </summary>
    /// <returns></returns>
    public int GetCoinNumber() {
        return intCoins;
    }

    /// <summary>
    /// Update a text field with the number of coins
    /// </summary>
    /// <param name="tmpCoinNumber"></param>
    public void GetCoinNumber(TextMeshProUGUI tmpCoinNumber) {
        tmpCoinNumber.text = "You earned: " + intCoins + " coins";
    }

    /// <summary>
    /// Add or remove coins to the total coin count
    /// </summary>
    /// <param name="movedCoins"></param>
    public void MoveCoins(int movedCoins) {
        if (intCoins + movedCoins < 0) {
            Debug.Log("Negative coins not allowed");
            return;
        } else {
            intCoins += movedCoins;
            tmpCoins.text = intCoins.ToString();
        }
    }
}
