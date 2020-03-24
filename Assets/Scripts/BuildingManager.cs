using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    public Stack<BuildingFloor> stkFloors;

    // Start is called before the first frame update
    void Start() {
        // Populate the stack of building floors
        List<BuildingFloor> listFloors = new List<BuildingFloor>();
        GetComponentsInChildren<BuildingFloor>(listFloors);
        stkFloors = new Stack<BuildingFloor>(listFloors);

        // Reset the health of the floor and all its furniture
        ResetFloorHealth();
    }

    /// <summary>
    /// Reset the health of the floor and all its furniture
    /// </summary>
    public void ResetFloorHealth() {
        if (stkFloors.Count > 0) {
            BuildingFloor floor = stkFloors.Peek();
            floor.ResetHealth();
            floor.PopulateFloor();
            var listFurns = floor.GetListFurniture();

            foreach (Furniture furniture in listFurns) {
                furniture.ResetHealth();
            }
        }
    }
}
