using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFloor : Destructable {

    public List<Furniture> listFurnitures = new List<Furniture>();

    /// <summary>
    /// Only decrease the health of the floor if all the furniture has been destroyed
    /// </summary>
    public override void DecreaseHealth() {
        if (listFurnitures.Count < 1) {
            base.DecreaseHealth();
        }
    }

}
