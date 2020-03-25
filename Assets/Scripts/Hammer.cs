using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer {

    int intHealth;

    const int HAMMER_MAX_HEALTH = 10;

    /// <summary>
    /// No-args Constructor of the Hammer
    /// </summary>
    Hammer() {
        intHealth = HAMMER_MAX_HEALTH;
    }

    /// <summary>
    /// Getter of the hammer health
    /// </summary>
    /// <returns></returns>
    public int GetHammerHealth() {
        return intHealth;
    }

    /// <summary>
    /// Decrease the health of the hammer
    /// </summary>
    public void DecreaseHealth() {
        intHealth--;
    }
}
