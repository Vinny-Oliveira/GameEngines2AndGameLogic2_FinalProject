using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Destructible : MonoBehaviour {

    [SerializeField]
    DestructableSO destructable;

    int health;
    bool canDestroy = false;

    ///// <summary>
    ///// Get the value of how many coins this object awards
    ///// </summary>
    ///// <returns></returns>
    //public int GetCoinValue() {
    //    return destructable.intCoinValue;
    //}

    /// <summary>
    /// Reset health according to value of the destructable SO
    /// </summary>
    public void ResetHealth() {
        canDestroy = true;
        health = destructable.intHealth;
    }

    /// <summary>
    /// Decrease health of the destructable object
    /// </summary>
    public virtual void DecreaseHealth() {
        health--;

        if (health < 1) {
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Event to detect mouse of touch down
    /// </summary>
    private void OnMouseDown() {
        if (canDestroy) {
            DecreaseHealth();
        }
    }

    /// <summary>
    /// Award the player with an amount of coins defined in this destructible
    /// </summary>
    public virtual void OnDisable() {
        CoinManager.instance.MoveCoins(destructable.intCoinValue);
    }
}
