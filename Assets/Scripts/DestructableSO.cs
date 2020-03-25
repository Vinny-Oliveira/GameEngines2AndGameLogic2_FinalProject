using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destructable sciptable object
/// </summary>
[CreateAssetMenu(fileName = "myDestructable", menuName = "Destructable/DestructableSO", order = 1)]
public class DestructableSO : ScriptableObject {

    public string strName;
    public int intHealth;
    public int intCoinValue;

}
