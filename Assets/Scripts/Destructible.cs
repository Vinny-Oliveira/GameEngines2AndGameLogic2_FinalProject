using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Destructible : MonoBehaviour {

    [SerializeField]
    DestructableSO destructable;

    int intHealth;
    bool canDestroy = false;

    /// <summary>
    /// Reset health according to value of the destructable SO
    /// </summary>
    public void ResetHealth() {
        canDestroy = true;
        intHealth = destructable.intHealth;
    }

    /// <summary>
    /// Decrease health of the destructable object
    /// </summary>
    public virtual void DecreaseHealth() {
        intHealth--;

        if (intHealth < 1) {
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Event to detect mouse of touch down
    /// </summary>
    private void OnMouseDown() {
        if (canDestroy) {
            DecreaseHealth();
            HammerManager.instance.HitAnObject();
        }
    }

    /// <summary>
    /// Award the player with an amount of coins defined in this destructible
    /// </summary>
    public virtual void OnDisable() {
        CoinManager.instance.MoveCoins(destructable.intCoinValue);
    }
}
