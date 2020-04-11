using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Class that manages what happens when the player wins or loses a level
/// </summary>
public class WinLossManager {

    static bool isRetrying = false;

    /// <summary>
    /// Get the retry state
    /// </summary>
    /// <returns></returns>
    public static bool GetRetryState() {
        return isRetrying;
    }

    /// <summary>
    /// Reset the retry state of the game
    /// </summary>
    /// <param name="retryState"></param>
    public static void SetRetryState(bool retryState) {
        isRetrying = retryState;
    }

    /// <summary>
    /// Display the panel for win or loss condition, whichever one is passed
    /// </summary>
    /// <param name="winLossPanel"></param>
    /// <param name="tmpReward"></param>
    public static void DisplayWinLossPanel(GameObject winLossPanel, TextMeshProUGUI tmpReward) {
        // Display proper UI information
        TimerManager.instance.DisableTimer();
        CoinManager.instance.GetCoinNumber(tmpReward);
        winLossPanel.SetActive(true);

        // Save the current data
        try { 
            CoinManager.instance.SaveCoinsToBank();
        } catch (System.InvalidOperationException ex) {
            Debug.Log(ex.Message);
        }
    }

}
