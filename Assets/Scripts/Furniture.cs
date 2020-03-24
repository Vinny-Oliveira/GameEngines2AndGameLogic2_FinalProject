using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour {

    [SerializeField]
    int health;

    // Constructors
    public Furniture() {
        health = 0;
    }

    public Furniture(int new_health) {
        health = new_health;
    }

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
