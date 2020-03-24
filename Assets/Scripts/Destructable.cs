using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Destructable : MonoBehaviour {

    [SerializeField]
    DestructableSO destructable;

    [SerializeField]
    int health;
    bool canDestroy = false;

    /// <summary>
    /// Getter of canDestroy
    /// </summary>
    /// <returns></returns>
    public bool GetCanDestroy() {
        return canDestroy;
    }

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

}
