using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour {

    // Count of the player's coins
    int intCoins;
    const int START_COINS = 0;

    // UI References
    //public TextMeshProUGUI tmpCoins;
    public Text tmpCoins;

    public static CoinManager instance;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        intCoins = START_COINS;
    }

    /// <summary>
    /// Add or remove coins to the total coin count
    /// </summary>
    /// <param name="movedCoins"></param>
    public void MoveCoins(int movedCoins) {
        if ((movedCoins < 0) && (intCoins + movedCoins < 0)) {
            Debug.Log("Negative coins not allowed");
            return;
        } else {
            intCoins += movedCoins;
            tmpCoins.text = intCoins.ToString();
        }
    }
}
