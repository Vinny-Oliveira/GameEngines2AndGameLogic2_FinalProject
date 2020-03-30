using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destructible sciptable object
/// </summary>
[CreateAssetMenu(fileName = "myDestructible", menuName = "Destructible/DestructibleSO", order = 1)]
public class DestructibleSO : ScriptableObject {

    public int intHealth;
    public int intCoinValue;

}
