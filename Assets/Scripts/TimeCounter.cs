using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that contains all the functions that deal with time
/// </summary>
public class TimeCounter : MonoBehaviour {

    protected int intTimer;
    protected bool isTimerEnabled;

    /// <summary>
    /// Getter for the timer value
    /// </summary>
    /// <returns></returns>
    public int GetTimer() {
        return intTimer;
    }

    /// <summary>
    /// Set the new time
    /// </summary>
    /// <param name="newTime"></param>
    public void SetTimer(int newTime) {
        intTimer = newTime;
    }

    /// <summary>
    /// Increase the time by a certain value
    /// </summary>
    /// <param name="addedTime"></param>
    public void IncreaseTimer(int addedTime) {
        intTimer += addedTime;
    }

    /// <summary>
    /// Get the timer state, enabled/disabled
    /// </summary>
    /// <returns></returns>
    public bool GetTimerState() {
        return isTimerEnabled;
    }

    /// <summary>
    /// Enable or disable the timer
    /// </summary>
    /// <param name="isOn"></param>
    public void SetTimerState(bool isOn) {
        isTimerEnabled = isOn;
    }

    /// <summary>
    /// Display the timer with the proper format
    /// </summary>
    public void DisplayTimer(int intTimer, TMPro.TextMeshProUGUI tmpTimer) {
        int intMinutes = intTimer / 60;
        int intSeconds = intTimer % 60;

        string strMinutes = ((intMinutes < 10) ? ("0" + intMinutes) : (intMinutes.ToString()));
        string strSeconds = ((intSeconds < 10) ? ("0" + intSeconds) : (intSeconds.ToString()));
        tmpTimer.text = strMinutes + ":" + strSeconds;
    }

    /// <summary>
    /// Run the timer continuosly until it zeroes
    /// </summary>
    /// <param name="tmpTimer"></param>
    /// <returns></returns>
    public IEnumerator RunTimer(TMPro.TextMeshProUGUI tmpTimer) {
        while ((intTimer > -1) && (isTimerEnabled)) {
            yield return new WaitForSeconds(1);

            DisplayTimer(intTimer, tmpTimer);
            intTimer--;
        }
    }

}
