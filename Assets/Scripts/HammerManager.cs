using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HammerManager : MonoBehaviour {

    Queue<Hammer> queHammers = new Queue<Hammer>();
    public int intStartingHammers;
    //public TextMeshProUGUI tmpHammerCount;
    public Text tmpHammerCount;
    public GameObject pnl_GameOver;

    public static HammerManager instance;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {
        PopulateHammerQueue(intStartingHammers);
        tmpHammerCount.text = queHammers.Count.ToString();
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

    /// <summary>
    /// The Hammer in the beginning of the queue hits an object and loses health
    /// </summary>
    public void HitAnObject() {
        queHammers.Peek().DecreaseHealth();
        
        if (queHammers.Peek().IsHammerBroken()) {
            queHammers.Dequeue();
            tmpHammerCount.text = queHammers.Count.ToString();

            if (queHammers.Count < 1) {
                pnl_GameOver.SetActive(true);
            }
        }
    }
}
