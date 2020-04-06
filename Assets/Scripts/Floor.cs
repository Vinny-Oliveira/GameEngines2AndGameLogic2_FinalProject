using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Model all the floors of building
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class Floor : Destructible {

    List<Furniture> listFurnitures = new List<Furniture>();

    /// <summary>
    /// Getter of the list of furnitures
    /// </summary>
    /// <returns></returns>
    public List<Furniture> GetListFurniture() {
        return listFurnitures;
    }

    /// <summary>
    /// Populate the list of Furniture objects that are children of this Floor
    /// </summary>
    public void PopulateFloor() {
        GetComponentsInChildren<Furniture>(listFurnitures);
    }

    /// <summary>
    /// Only decrease the health of the floor if all the furniture has been destroyed
    /// </summary>
    public override void DecreaseHealth() {
        if (listFurnitures.Count < 1) {
            base.DecreaseHealth();
        }
    }

    /// <summary>
    /// Enable the next floor to be destroyed
    /// </summary>
    public override void DisableObject() {
        base.DisableObject();
        BuildingManager building = transform.parent.GetComponent<BuildingManager>();
        building.stkFloors.Pop();
        building.ResetFloorHealth();
    }
}
