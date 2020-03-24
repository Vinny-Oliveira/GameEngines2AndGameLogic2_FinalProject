using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

    public Stack<BuildingFloor> stkFloors;

    [SerializeField]
    List<BuildingFloor> listFloors = new List<BuildingFloor>();

    // Start is called before the first frame update
    void Start() {
        stkFloors = new Stack<BuildingFloor>(listFloors);

        BuildingFloor floor = stkFloors.Peek();
        floor.ResetHealth();
        var listFurns = floor.listFurnitures;
        
        foreach (Furniture furniture in listFurns) {
            furniture.ResetHealth();
        }
    }


}
