using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class that manages what happens when the player wins or loses a level
/// </summary>
public class WinLossManager {

    /// <summary>
    /// Display the panel for win or loss condition, whichever one is passed
    /// </summary>
    /// <param name="winLossPanel"></param>
    public static void DisplayWinLossPanel(GameObject winLossPanel, TextMeshProUGUI tmpReward) {
        // Display proper UI information
        TimerManager.instance.DisableTimer();
        CoinManager.instance.GetCoinNumber(tmpReward);
        winLossPanel.SetActive(true);

        // Save the current data
        CoinManager.instance.SaveCoinsToBank();
    }

}
