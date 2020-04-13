using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using TimeCounter;

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
    public TextMeshProUGUI tmpReward;
    public GameObject pnl_TimesUp;

    [Header("Time Animation")]
    public Animator animatorTime;
    public AudioSource audioSource;

    //bool isTimerEnabled;
    TimeConter timeConter = new TimeConter();

    // Start is called before the first frame update
    void Start() {
        timeConter.intTimer = intTimer;
        WinLossManager.SetRetryState(false);
        StartTimer();
    }

    /// <summary>
    /// Getter for the timer value
    /// </summary>
    /// <returns></returns>
    public int GetTimer() {
        return timeConter.intTimer;
    }

    /// <summary>
    /// Setter for the timer value
    /// </summary>
    /// <param name="newTime"></param>
    public void SetTimer(int newTime) {
        timeConter.intTimer = newTime;
        timeConter.DisplayTimer(timeConter.intTimer, tmpTimer);
    }

    /// <summary>
    /// Enable the timer and run it
    /// </summary>
    public void StartTimer() {
        timeConter.isTimerEnabled = true;
        StartCoroutine(RunTimer());
    }

    /// <summary>
    /// Run the timer continuosly until it zeroes
    /// </summary>
    /// <returns></returns>
    IEnumerator RunTimer() {

        yield return StartCoroutine(timeConter.RunTimer(tmpTimer));

        if (timeConter.intTimer < 1) {
            timeConter.intTimer = 0;
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
        timeConter.isTimerEnabled = false;
    }

    /// <summary>
    /// Increase the timer
    /// </summary>
    /// <param name="timeBoost"></param>
    public void BoostTimer(int timeBoost) {
        if (timeBoost > 0) {
            timeConter.intTimer += timeBoost;
            //DisplayTimer();
            timeConter.DisplayTimer(intTimer, tmpTimer);
            tmpTimeBooster.text = "+" + timeBoost;
            animatorTime.SetTrigger(animatorTime.parameters[0].name);
            if (audioSource == null) {
                audioSource = GetComponent<AudioSource>();
            }
            audioSource.Play();
        }
    }

    ///// <summary>
    ///// Display the timer with the proper format
    ///// </summary>
    //void DisplayTimer() {
    //    int intMinutes = intTimer / 60;
    //    int intSeconds = intTimer % 60;

    //    string strMinutes = ((intMinutes < 10) ? ("0" + intMinutes) : (intMinutes.ToString()));
    //    string strSeconds = ((intSeconds < 10) ? ("0" + intSeconds) : (intSeconds.ToString()));
    //    tmpTimer.text = strMinutes + ":" + strSeconds;
    //}
}
