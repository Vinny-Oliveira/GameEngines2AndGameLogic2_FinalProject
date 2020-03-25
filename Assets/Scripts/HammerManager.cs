using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HammerManager : MonoBehaviour {

    Queue<Hammer> queHammers = new Queue<Hammer>();
    public int intStartingHammers;
    public TextMeshProUGUI tmpHammerCount;

    // Start is called before the first frame update
    void Start() {
        PopulateHammerQueue(intStartingHammers);
    }

    /// <summary>
    /// Populate the queue of hammers with the starting number of hammers
    /// </summary>
    /// <param name="amountHammers"></param>
    public void PopulateHammerQueue(int amountHammers) { 
        for (int i = 0; i < amountHammers; i++) {
            queHammers.Enqueue(new Hammer());
        }
    }
}
