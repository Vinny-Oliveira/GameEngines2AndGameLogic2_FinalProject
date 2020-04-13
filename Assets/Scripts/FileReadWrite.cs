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

    // Json file name and path
    static string jsonFileName = "savedData.json";
    static string jsonFilePath;// = Application.streamingAssetsPath + "/savedData.json";

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
        string jsonFilePath;

        if (Directory.Exists(Application.persistentDataPath)) {
            jsonFilePath = Path.Combine(Application.persistentDataPath, jsonFileName);
        } else {
            jsonFilePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);
        }

        if (!File.Exists(jsonFilePath)) {
            File.Create(jsonFilePath).Close();
        }

        dataString = JsonUtility.ToJson(savedData);
        File.WriteAllText(jsonFilePath, dataString);
//        //#if UNITY_EDITOR
//        jsonFilePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);
//        //#elif UNITY_ANDROID
//        jsonFilePath = Path.Combine(Application.persistentDataPath, jsonFileName);

        
////#endif
//        File.WriteAllText(jsonFilePath, dataString);
        //StreamWriter writer = new StreamWriter(filePath);
        //writer.Write(dataString);
        //writer.Close();
    }

    /// <summary>
    /// Load data from a json file
    /// </summary>
    public static void ReadDataFromJson() {
        //jsonFilePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);
        string dataString;
//#if UNITY_EDITOR
        
        //#elif UNITY_ANDROID
        //jsonFilePath = Path.Combine(Application.persistentDataPath, jsonFileName);

        if (Directory.Exists(Application.persistentDataPath)) {
            jsonFilePath = Path.Combine(Application.persistentDataPath, jsonFileName);
        } else {
            jsonFilePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);
        }

        if (!File.Exists(jsonFilePath)) {
            File.Create(jsonFilePath).Close();

            var newQueue = new Queue<Hammer>();
            for (int i = 0; i < 10; i++) {
                newQueue.Enqueue(new Hammer());
            }

            SetSavedData(0, newQueue);
            dataString = JsonUtility.ToJson(savedData);
            File.WriteAllText(jsonFilePath, dataString);
        }
        //WWW reader = new WWW(jsonFilePath);
        //while (!reader.isDone) { } // Do nothing
        //dataString = reader.text;
        //#endif
        dataString = File.ReadAllText(jsonFilePath);
        loadedData = JsonUtility.FromJson<SavedData>(dataString);
    }

}
