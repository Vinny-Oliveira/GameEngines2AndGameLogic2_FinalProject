using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// All data that is saved by the user
/// </summary>
public struct SavedData {
    int totalCoins;

    public int GetTotalCoins() { return totalCoins; }
    public void SetTotalCoins(int newCoins) { totalCoins = newCoins; }
}

/// <summary>
/// Read and write data from and to a json file
/// </summary>
public class FileReadWrite {

    // Saved and loaded datas
    static SavedData savedData = new SavedData();
    static SavedData loadedData = new SavedData();

    // Json file path
    static string jsonFilePath = Application.streamingAssetsPath + "savedData.json";

    /// <summary>
    /// Save a data string to a json file
    /// </summary>
    public void WriteDataToJson() {
        Debug.Log("SAVING DATA TO JSON FILE");

        string dataString = JsonUtility.ToJson(savedData);
        File.WriteAllText(jsonFilePath, dataString);
    }

    /// <summary>
    /// Load data from a json file
    /// </summary>
    public void ReadDataFromJson() {
        string dataString = File.ReadAllText(jsonFilePath);
        loadedData = JsonUtility.FromJson<SavedData>(dataString);
    }

}
