using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsManager {

    // Analytics events for the 1st game over
    static int intCoinsLeft1stGameOver;        static string eventCoinsLeft1stGameOver;
    static int intHammersLeft1stGameOver;      static string eventHammersLeft1stGameOver;
    static int intBank1stGameOver;             static string eventBank1stGameOver;
    static int intFirstGameOverCount;          static string eventFirstGameOverCount;

    // Analytics events for the 2nd game over
    static int intRetryCount;                  static string eventRetryCount;
    static int intCoinsLeft2stGameOver;        static string eventCoinsLeft2stGameOver;
    static int intHammersLeft2stGameOver;      static string eventHammersLeft2stGameOver;
    static int intSecondGameOverCount;         static string eventSecondGameOverCount;

    // Analytics events for win
    static int intCoinsLeftWin;                static string eventCoinsLeftWin;
    static int intHammersLeftWin;              static string eventHammersLeftWin;
    static int intWinCount;                    static string eventWinCount;

    public static void Increase1stGameOverAnalytics() {
        intCoinsLeft1stGameOver++;
        intHammersLeft1stGameOver++;
        intBank1stGameOver++;
        intFirstGameOverCount++;
    }

    public static void SendAnalytics() {
        Dictionary<string, object> analyticsData = new Dictionary<string, object>();
        //analyticsData.Add();

    }
}
