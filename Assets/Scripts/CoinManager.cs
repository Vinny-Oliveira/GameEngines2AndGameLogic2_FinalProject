using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {

    int intCoins;

    const int START_COINS = 0;

    private void Start() {
        intCoins = START_COINS;
    }

    /// <summary>
    /// Add or remove coins to the total coin count
    /// </summary>
    /// <param name="movedCoins"></param>
    public void CoinManipulator(int movedCoins) {
        intCoins += movedCoins;
    }


}
