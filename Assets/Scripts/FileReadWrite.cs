using System.Collections;
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

    // Json file name
    static readonly string jsonFileName = "savedData.json";

    // Starting hammers for a brand new game
    static readonly int startingHammers = 15;

    /// <summary>
    /// Set new values for the saved data
    /// </summary>
    /// <param name="newCoins"></param>
    static void SetSavedData(int newCoins, Queue<Hammer> newHammers) { 
        savedData.totalCoins = newCoins;
        savedData.hammers = newHammers.ToList();
    }

    /// <summary>
    /// Save a data string to a json file
    /// </summary>
    public static void WriteDataToJson() {
        Debug.Log("SAVING DATA TO JSON FILE");

        string dataString;
        string jsonFilePath = DataPath();
        CheckFileExistance(jsonFilePath);

        dataString = JsonUtility.ToJson(savedData);
        File.WriteAllText(jsonFilePath, dataString);
    }

    /// <summary>
    /// Save a data string to a json file
    /// </summary>
    /// <param name="newCoins"></param>
    /// <param name="newHammers"></param>
    public static void WriteDataToJson(int newCoins, Queue<Hammer> newHammers) {
        SetSavedData(newCoins, newHammers);
        WriteDataToJson();
    }

    /// <summary>
    /// Load data from a json file
    /// </summary>
    public static SavedData ReadDataFromJson() {
        string dataString;
        string jsonFilePath = DataPath();
        CheckFileExistance(jsonFilePath, true);

        dataString = File.ReadAllText(jsonFilePath);
        loadedData = JsonUtility.FromJson<SavedData>(dataString);
        return loadedData;
    }

    /// <summary>
    /// Give a first time player a starting amount of hammers
    /// </summary>
    static void SetStartingData() {
        var newQueue = new Queue<Hammer>();
        for (int i = 0; i < startingHammers; i++) {
            newQueue.Enqueue(new Hammer());
        }

        SetSavedData(0, newQueue);
    }

    /// <summary>
    /// Set the saved data's file path
    /// </summary>
    /// <returns></returns>
    static string DataPath() { 
        if (Directory.Exists(Application.persistentDataPath)) {
            return Path.Combine(Application.persistentDataPath, jsonFileName);
        }
        return Path.Combine(Application.streamingAssetsPath, jsonFileName);
    }

    /// <summary>
    /// Check if the file exists and, if you are trying to read it, set a starting data for it
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="isReading"></param>
    static void CheckFileExistance(string filePath, bool isReading = false) {
        if (!File.Exists(filePath)){
            File.Create(filePath).Close();
            if (isReading) { 
                SetStartingData();
                string dataString = JsonUtility.ToJson(savedData);
                File.WriteAllText(filePath, dataString);
            }
        }
    }
}
