using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour {

    [Header("Starting Time")]
    public int intTimer;

    [Header("UI References")]
    public TextMeshProUGUI tmpTimer;
    public TextMeshProUGUI tmpReward;
    public GameObject pnl_GameOver;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(DisplayTimer());
    }

    /// <summary>
    /// Display the timer
    /// </summary>
    /// <returns></returns>
    IEnumerator DisplayTimer() {

        while ((intTimer > -1) && (!pnl_GameOver.activeInHierarchy)) {
            yield return new WaitForSeconds(1);

            int intMinutes = intTimer / 60;
            int intSeconds = intTimer % 60;

            string strMinutes = ((intMinutes < 10) ? ("0" + intMinutes) : (intMinutes.ToString()));
            string strSeconds = ((intSeconds < 10) ? ("0" + intSeconds) : (intSeconds.ToString()));
            tmpTimer.text = strMinutes + ":" + strSeconds;

            intTimer--;
        }

        CoinManager.instance.GetCoinNumber(tmpReward);
        pnl_GameOver.SetActive(true);
    }
}
