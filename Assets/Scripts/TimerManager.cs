using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

/// <summary>
/// Manage the timer of the level
/// </summary>
public class TimerManager : SingletonManager<TimerManager> {

    [Header("Starting Time")]
    [SerializeField]
    int intTimer;

    [Header("UI References")]
    public TextMeshProUGUI tmpTimer;
    public TextMeshProUGUI tmpTimeBooster;
    public Animator animatorTime;
    public TextMeshProUGUI tmpReward;
    public GameObject pnl_TimesUp;

    bool isTimerEnabled;

    // Start is called before the first frame update
    void Start() {
        WinLossManager.SetRetryState(false);
        StartTimer();
    }

    /// <summary>
    /// Getter for the timer value
    /// </summary>
    /// <returns></returns>
    public int GetTimer() {
        return intTimer;
    }

    /// <summary>
    /// Setter for the timer value
    /// </summary>
    /// <param name="newTime"></param>
    public void SetTimer(int newTime) {
        intTimer = newTime;
        DisplayTimer();
    }

    /// <summary>
    /// Enable the timer and run it
    /// </summary>
    public void StartTimer() {
        isTimerEnabled = true;
        StartCoroutine(RunTimer());
    }

    /// <summary>
    /// Run the timer continuosly until it zeroes
    /// </summary>
    /// <returns></returns>
    IEnumerator RunTimer() {

        while ((intTimer > -1) && (isTimerEnabled)) {
            yield return new WaitForSeconds(1);

            DisplayTimer();
            intTimer--;
        }

        if (intTimer < 1) {
            intTimer = 0;
            if (WinLossManager.GetRetryState()) {
                AnalyticsManager.Increase2ndGameOverAnalytics();
            } else {
                AnalyticsManager.Increase1stGameOverAnalytics();
            }

            WinLossManager.DisplayWinLossPanel(pnl_TimesUp, tmpReward);
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
        if (timeBoost > 0) { 
            intTimer += timeBoost;
            DisplayTimer();
            tmpTimeBooster.text = "+" + timeBoost;
            animatorTime.SetTrigger(animatorTime.parameters[0].name);
        }
    }

    /// <summary>
    /// Display the timer with the proper format
    /// </summary>
    void DisplayTimer() {
        int intMinutes = intTimer / 60;
        int intSeconds = intTimer % 60;

        string strMinutes = ((intMinutes < 10) ? ("0" + intMinutes) : (intMinutes.ToString()));
        string strSeconds = ((intSeconds < 10) ? ("0" + intSeconds) : (intSeconds.ToString()));
        tmpTimer.text = strMinutes + ":" + strSeconds;
    }
}
