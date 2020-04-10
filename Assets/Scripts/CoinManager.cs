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
        FileReadWrite.ReadDataFromJson();
        SavedData loadedData = FileReadWrite.GetLoadedData();
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
        SaveBankToFile();
    }

    /// <summary>
    /// Save the number of coins in the banl to a json file
    /// </summary>
    void SaveBankToFile() {
        FileReadWrite.SetSavedData(intBankOfCoins, HammerManager.instance.GetHammers());
        FileReadWrite.WriteDataToJson();
        Debug.Log("Coins in bank: " + intBankOfCoins);
    }
}
