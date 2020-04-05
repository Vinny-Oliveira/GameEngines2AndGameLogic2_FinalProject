using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Allow the player to continue a level after they have made IAPs
/// </summary>
public class Level_Retryer : MonoBehaviour {

    public Button btnRetry;
    public GameObject pnl_GameOver;

    /// <summary>
    /// Try to finish the level one more time
    /// </summary>
    public void RetryLevel() {
        if (btnRetry == null) { 
            btnRetry = GetComponent<Button>(); 
        }

        pnl_GameOver.SetActive(false);
        btnRetry.interactable = false;
        TimerManager.instance.StartTimer();
    }

}
