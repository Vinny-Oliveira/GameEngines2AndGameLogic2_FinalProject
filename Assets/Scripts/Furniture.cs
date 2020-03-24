using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour {

    [SerializeField]
    int health;

    // Constructors
    Furniture() {
        health = 0;
    }

    Furniture(int new_health) {
        health = new_health;
    }

    // Member methods

    /// <summary>
    /// Decrease health of the object
    /// </summary>
    public void DecreaseHealth() {
        health--;

        if (health < 1) {
            gameObject.SetActive(false);
        }
    }
}
