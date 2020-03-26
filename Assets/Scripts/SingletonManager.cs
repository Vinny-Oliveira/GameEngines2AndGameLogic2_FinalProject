using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager<T> : MonoBehaviour where T: SingletonManager<T> {

    public static T instance;

    private void Awake() {
        instance = this.GetComponent<T>();
    }

}
