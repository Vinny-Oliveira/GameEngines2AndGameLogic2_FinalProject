using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour {

    int intHammerHealth;
    int intCoins;
    bool isHammerBroken = false;

    const int START_HAMMER_HEALTH = 10;
    const int START_COINS = 0;

    public static ItemsManager instance;

    private void Start() {
        intHammerHealth = START_HAMMER_HEALTH;
        intCoins = START_COINS;
        isHammerBroken = false;
    }

    /// <summary>
    /// Decrease the health of the hammer
    /// </summary>
    public void DecreaseHammerHealth() {
        intHammerHealth--;

        if (intHammerHealth < 1) {
            isHammerBroken = true;
        }
    }

}
