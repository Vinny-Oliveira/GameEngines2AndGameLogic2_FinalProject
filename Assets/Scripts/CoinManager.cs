using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manage how the player gains and spends coins
/// </summary>
public class CoinManager : SingletonManager<CoinManager> {

    // Count of the player's coins
    static int intBankOfCoins;
    int intCoinsInLevel;
    const int START_COINS = 0;

    // UI References
    public TextMeshProUGUI tmpCoins;

    private void Start() {
        intCoinsInLevel = START_COINS;
    }

    /// <summary>
    /// Get the total number of coins
    /// </summary>
    /// <returns></returns>
    public int GetCoinNumber() {
        return intCoinsInLevel;
    }

    /// <summary>
    /// Update a text field with the number of coins
    /// </summary>
    /// <param name="tmpCoinNumber"></param>
    public void GetCoinNumber(TextMeshProUGUI tmpCoinNumber) {
        tmpCoinNumber.text = "You earned: " + intCoinsInLevel + " coins";
    }

    /// <summary>
    /// Add or remove coins to the total coin count
    /// </summary>
    /// <param name="coinsGained"></param>
    public void GainCoins(int coinsGained) {
        intCoinsInLevel += coinsGained;
        tmpCoins.text = intCoinsInLevel.ToString();
    }
}
