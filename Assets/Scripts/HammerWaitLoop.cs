using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manage the wait loop that rewards the player with extra hammers
/// </summary>
public class HammerWaitLoop : TimeCounter {

    [SerializeField]
    int loopTime;
    [SerializeField]
    int maxHammers;

    public TextMeshProUGUI tmpTimer;

    /// <summary>
    /// Check if the current number of hammers the player has is less then the max amount allowed to loop
    /// </summary>
    /// <returns></returns>
    public bool CanLoop() {
        return (HammerManager.instance.GetHammers().Count < maxHammers);
    }

    /// <summary>
    /// Run the wait loop and reward the player with an extra hammer when it ends
    /// </summary>
    /// <returns></returns>
    public IEnumerator RunWaitLoop() {
        intTimer = loopTime;
        isTimerEnabled = true;
        yield return StartCoroutine(RunTimer(tmpTimer));
        RewardWithExtraHammer();
    }

    /// <summary>
    /// Give the player an extra hammer and check if another loop may start
    /// </summary>
    void RewardWithExtraHammer() {
        HammerManager.instance.PopulateHammerQueue(1);
        CoinManager.instance.SaveBankAndHammers();
        if (CanLoop()) {
            StartCoroutine(RunWaitLoop());
        } else {
            DisplayTimer(0, tmpTimer);
        }
    }

}
