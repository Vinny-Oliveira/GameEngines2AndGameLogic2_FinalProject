using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Model all the furniture of the building
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Furniture : Destructible {

    /// <summary>
    /// When disabled, remove itself from the list of Furniture objects
    /// </summary>
    public override void DisableObject() {
        base.DisableObject();
        Floor floor = transform.parent.GetComponent<Floor>();
        floor.GetListFurniture().Remove(this);
    }

}
