using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Destructable : MonoBehaviour {

    [SerializeField]
    DestructableSO destructable;
    [SerializeField]
    int health;

    /// <summary>
    /// Reset health according to value of the destructable SO
    /// </summary>
    public void ResetHealth() {
        health = destructable.intHealth;
    }

    /// <summary>
    /// Reset health of a destructable object
    /// </summary>
    /// <param name="listDestructables"></param>
    public void ResetHealth(ref Destructable myDestructable) {
        myDestructable.ResetHealth();
    }
    
    /// <summary>
    /// Reset health of a list of destructables
    /// </summary>
    /// <param name="listDestructables"></param>
    public void ResetHealth(ref List<Destructable> listDestructables) {
        foreach (Destructable destructable in listDestructables) {
            destructable.ResetHealth();
        }
    }

    /// <summary>
    /// Decrease health of the destructable object
    /// </summary>
    public void DecreaseHealth() {
        health--;

        if (health < 1) {
            gameObject.SetActive(false);
        }
    }

}
