using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLossManager {

    /// <summary>
    /// Display the panel for or loss condition, whichever one is passed
    /// </summary>
    /// <param name="winLossPanel"></param>
    public static void DisplayWinLossPanel(GameObject winLossPanel, TextMeshProUGUI tmpReward) {
        TimerManager.instance.DisableTimer();
        CoinManager.instance.GetCoinNumber(tmpReward);
        winLossPanel.SetActive(true);
    }

}
