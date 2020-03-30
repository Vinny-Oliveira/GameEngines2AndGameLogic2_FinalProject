using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manage all the hammer objects used to destroy the building
/// </summary>
public class HammerManager : SingletonManager<HammerManager> {

    Queue<Hammer> queHammers = new Queue<Hammer>();

    [Header("Hammer Management")]
    public int intStartingHammers;
    public int intHammerHealth;
    
    [Header("UI References")]
    public TextMeshProUGUI tmpHammerCount;
    public TextMeshProUGUI tmpReward;
    public GameObject pnl_GameOver;

    // Start is called before the first frame update
    void Start() {
        PopulateHammerQueue(intStartingHammers, intHammerHealth);
        tmpHammerCount.text = queHammers.Count.ToString();
    }

    /// <summary>
    /// Populate the queue of hammers with the starting number of hammers
    /// </summary>
    /// <param name="amountHammers"></param>
    public void PopulateHammerQueue(int amountHammers, int healthOfHammers) { 
        for (int i = 0; i < amountHammers; i++) {
            queHammers.Enqueue(new Hammer(healthOfHammers));
        }
    }

    /// <summary>
    /// The Hammer in the beginning of the queue hits an object and loses health
    /// </summary>
    public void HitAnObject() {
        if (queHammers.Count < 1) {
            WinLossManager.DisplayWinLossPanel(pnl_GameOver, tmpReward);
            return;
        }
        
        queHammers.Peek().DecreaseHealth();
        
        if (queHammers.Peek().IsHammerBroken()) {
            queHammers.Dequeue();
            tmpHammerCount.text = queHammers.Count.ToString();
        }
    }
}
