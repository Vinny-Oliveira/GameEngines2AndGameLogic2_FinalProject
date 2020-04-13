﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

/// <summary>
/// All data that is saved by the user
/// </summary>
public class SavedData {
    public int totalCoins;
    public List<Hammer> hammers = new List<Hammer>();
}

/// <summary>
/// Read and write data from and to a json file
/// </summary>
public class FileReadWrite {

    // Saved and loaded datas
    static SavedData savedData = new SavedData();
    static SavedData loadedData = new SavedData();

    // Json file path
    static string jsonFilePath = Application.streamingAssetsPath + "/savedData.json";

    /// <summary>
    /// Get the loaded data
    /// </summary>
    /// <returns></returns>
    public static SavedData GetLoadedData() { 
        return loadedData; 
    }

    /// <summary>
    /// Set new values for the saved data
    /// </summary>
    /// <param name="newCoins"></param>
    public static void SetSavedData(int newCoins, Queue<Hammer> newHammers) { 
        savedData.totalCoins = newCoins;
        savedData.hammers = newHammers.ToList();
    }

    /// <summary>
    /// Save a data string to a json file
    /// </summary>
    public static void WriteDataToJson() {
        Debug.Log("SAVING DATA TO JSON FILE");

        string dataString = JsonUtility.ToJson(savedData);
        File.WriteAllText(jsonFilePath, dataString);
    }

    /// <summary>
    /// Load data from a json file
    /// </summary>
    public static void ReadDataFromJson() {
        string dataString;
#if UNITY_EDITOR
        dataString = File.ReadAllText(jsonFilePath);
#elif UNITY_ANDROID
        WWW reader = new WWW(jsonFilePath);
        while (!reader.isDone) { } // Do nothing
        dataString = reader.text;
#endif
        loadedData = JsonUtility.FromJson<SavedData>(dataString);
    }

}
