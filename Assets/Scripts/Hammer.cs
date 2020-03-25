using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer {

    int intHealth;

    const int HAMMER_MAX_HEALTH = 5;

    /// <summary>
    /// No-args Constructor of the Hammer
    /// </summary>
    public Hammer() {
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

    /// <summary>
    /// Check if the hammer's health is less than zero
    /// </summary>
    /// <returns></returns>
    public bool IsHammerBroken() {
        return (intHealth < 1);
    }
}
