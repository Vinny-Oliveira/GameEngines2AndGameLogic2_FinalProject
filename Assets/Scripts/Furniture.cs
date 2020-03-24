using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : Destructible {

    /// <summary>
    /// When disabled, remove itself from the list of Furniture objects
    /// </summary>
    private void OnDisable() {
        BuildingFloor floor = transform.parent.GetComponent<BuildingFloor>();
        floor.listFurnitures.Remove(this);
    }

}
