using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;
using TimeCounting;

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
    TimeCounter timeCounter = new TimeCounter();

    // Start is called before the first frame update
    void Start() {
        timeCounter.intTimer = intTimer;
        WinLossManager.SetRetryState(false);
        StartTimer();
    }

    /// <summary>
    /// Getter for the timer value
    /// </summary>
    /// <returns></returns>
    public int GetTimer() {
        return timeCounter.intTimer;
    }

    /// <summary>
    /// Setter for the timer value
    /// </summary>
    /// <param name="newTime"></param>
    public void SetTimer(int newTime) {
        timeCounter.intTimer = newTime;
        timeCounter.DisplayTimer(timeCounter.intTimer, tmpTimer);
    }

    /// <summary>
    /// Enable the timer and run it
    /// </summary>
    public void StartTimer() {
        timeCounter.isTimerEnabled = true;
        StartCoroutine(RunTimer());
    }

    /// <summary>
    /// Run the timer continuosly until it zeroes
    /// </summary>
    /// <returns></returns>
    IEnumerator RunTimer() {
        yield return StartCoroutine(timeCounter.RunTimer(tmpTimer));
        HandleTimerStop();
    }

    /// <summary>
    /// Handle what happens when the timer stops running, whether because it has run out or if is was disabled
    /// </summary>
    void HandleTimerStop() { 
        if (timeCounter.intTimer < 1) {
            timeCounter.intTimer = 0;
            WinLossManager.SendGameOverAnalytics(pnl_TimesUp, tmpReward);
        }
    }

    /// <summary>
    /// Disable the timer
    /// </summary>
    public void DisableTimer() {
        timeCounter.isTimerEnabled = false;
    }

    /// <summary>
    /// Increase the timer
    /// </summary>
    /// <param name="timeBoost"></param>
    public void BoostTimer(int timeBoost) {
        if (timeBoost > 0) {
            timeCounter.intTimer += timeBoost;
            timeCounter.DisplayTimer(timeCounter.intTimer, tmpTimer);
            tmpTimeBooster.text = "+" + timeBoost;
            animatorTime.SetTrigger(animatorTime.parameters[0].name);
            if (audioSource == null) {
                audioSource = GetComponent<AudioSource>();
            }
            audioSource.Play();
        }
    }
}
