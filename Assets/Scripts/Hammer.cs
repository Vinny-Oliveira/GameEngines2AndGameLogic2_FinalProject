using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Model Hammer objects that are used to destroy the building of the game
/// </summary>
[System.Serializable]
public class Hammer {

    public int intHealth;

    static int defaultMaxHealth = 5;

    /// <summary>
    /// No-args Constructor of the Hammer
    /// </summary>
    public Hammer() {
        intHealth = defaultMaxHealth;
    }

    /// <summary>
    /// Constructor with custom health
    /// </summary>
    /// <param name="newHealth"></param>
    public Hammer(int newHealth) {
        intHealth = newHealth;
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
