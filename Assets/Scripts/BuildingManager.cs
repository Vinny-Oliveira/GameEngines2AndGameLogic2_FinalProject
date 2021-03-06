﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Manage how the floors of the building and their respective furnitures lose health and are organized on the stack
/// Place this script on the Empty Game Object that holds all the building floors
/// </summary>
public class BuildingManager : MonoBehaviour {

    public Stack<Floor> stkFloors;
    public GameObject pnl_Congrats;
    public TextMeshProUGUI tmpReward;

    // Start is called before the first frame update
    void Start() {
        // Populate the stack of building floors
        List<Floor> listFloors = new List<Floor>();
        GetComponentsInChildren<Floor>(listFloors);
        stkFloors = new Stack<Floor>(listFloors);

        // Reset the health of the floor and all its furniture
        ResetFloorHealth();
    }

    /// <summary>
    /// Reset the health of the floor and all its furniture
    /// </summary>
    public void ResetFloorHealth() {
        if (stkFloors.Count > 0) {
            Floor floor = stkFloors.Peek();
            floor.ResetHealth();
            floor.PopulateFloor();
            var listFurns = floor.GetListFurniture();

            foreach (Furniture furniture in listFurns) {
                furniture.ResetHealth();
            }
        
        } else { // All floors destroyed = player wins
            AnalyticsManager.IncreaseWinAnalytics();
            WinLossManager.DisplayWinLossPanel(pnl_Congrats, tmpReward);
        }
    }
}
