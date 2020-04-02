using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manage the timer of the level
/// </summary>
public class TimerManager : SingletonManager<TimerManager> {

    [Header("Starting Time")]
    public int intTimer;

    [Header("UI References")]
    public TextMeshProUGUI tmpTimer;
    public TextMeshProUGUI tmpTimeBooster;
    public TextMeshProUGUI tmpReward;
    public GameObject pnl_GameOver;

    bool isTimerEnabled;

    // Start is called before the first frame update
    void Start() {
        isTimerEnabled = true;
        StartCoroutine(DisplayTimer());
    }

    /// <summary>
    /// Display the timer
    /// </summary>
    /// <returns></returns>
    IEnumerator DisplayTimer() {

        while ((intTimer > -1) && (isTimerEnabled)) {
            yield return new WaitForSeconds(1);

            int intMinutes = intTimer / 60;
            int intSeconds = intTimer % 60;

            string strMinutes = ((intMinutes < 10) ? ("0" + intMinutes) : (intMinutes.ToString()));
            string strSeconds = ((intSeconds < 10) ? ("0" + intSeconds) : (intSeconds.ToString()));
            tmpTimer.text = strMinutes + ":" + strSeconds;

            intTimer--;
        }

        if (intTimer < 1) { 
            WinLossManager.DisplayWinLossPanel(pnl_GameOver, tmpReward);
        }
    }

    /// <summary>
    /// Disable the timer
    /// </summary>
    public void DisableTimer() {
        isTimerEnabled = false;
    }

    /// <summary>
    /// Increase the timer
    /// </summary>
    /// <param name="timeBoost"></param>
    public void BoostTimer(int timeBoost) {
        intTimer += timeBoost;
        tmpTimeBooster.text = "+" + timeBoost;
    }
}
