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

    // UI References
    public TextMeshProUGUI tmpCoins;

    private void Start() {
        intCoinsInLevel = 0;
        SavedData loadedData = FileReadWrite.ReadDataFromJson();
        intBankOfCoins = loadedData.totalCoins;
        HammerManager.instance.SetHammers(loadedData.hammers);
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
        tmpCoinNumber.text = intCoinsInLevel.ToString();
    }

    /// <summary>
    /// Add or remove coins to the total coin count
    /// </summary>
    /// <param name="coinsGained"></param>
    public void GainCoins(int coinsGained) {
        intCoinsInLevel += coinsGained;
        tmpCoins.text = intCoinsInLevel.ToString();
    }

    /// <summary>
    /// Get the number of coins in the bank
    /// </summary>
    /// <returns></returns>
    public int GetBank() {
        return intBankOfCoins;
    }

    /// <summary>
    /// Save the total number of coins gained in the level
    /// </summary>
    /// <returns></returns>
    public void SaveCoinsToBank() {
        SaveCoinsToBank(intCoinsInLevel);
        intCoinsInLevel = 0;
    }

    /// <summary>
    /// Save a determined amount of coins
    /// </summary>
    /// <returns></returns>
    public void SaveCoinsToBank(int coinsToSave) {
        if (intBankOfCoins + coinsToSave < 0) {
            throw new System.InvalidOperationException("No coins available for this purchase.");
        }

        intBankOfCoins += coinsToSave;
        SaveBankAndHammers();
    }

    /// <summary>
    /// Save the number of coins in the bank and the current hammers to a json file
    /// </summary>
    public void SaveBankAndHammers() {
        FileReadWrite.WriteDataToJson(intBankOfCoins, HammerManager.instance.GetHammers());
        Debug.Log("Coins in bank: " + intBankOfCoins);
    }
}
