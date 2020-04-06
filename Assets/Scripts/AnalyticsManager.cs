using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsManager {

    // Analytics events for the 1st game over
    static int intCoinsLeft1stGameOver;        const string eventCoinsLeft1stGameOver = "Coins left 1st game over";
    static int intHammersLeft1stGameOver;      const string eventHammersLeft1stGameOver = "Hammers left 1st game over";
    static int intBank1stGameOver;             const string eventBank1stGameOver = "Bank 1st game over";
    static int intFirstGameOverCount;          const string eventFirstGameOverCount = "1st game over count";

    // Analytics events for the 2nd game over
    static int intRetryCount;                  const string eventRetryCount = "Retry count";
    static int intCoinsLeft2stGameOver;        const string eventCoinsLeft2stGameOver = "Coind left 2nd game over";
    static int intHammersLeft2stGameOver;      const string eventHammersLeft2stGameOver = "Hammers left 2nd game over";
    static int intSecondGameOverCount;         const string eventSecondGameOverCount = "2nd game over count";

    // Analytics events for win
    static int intCoinsLeftWin;                const string eventCoinsLeftWin = "Coins left win";
    static int intHammersLeftWin;              const string eventHammersLeftWin = "Hammers left win";
    static int intWinCount;                    const string eventWinCount = "Win count";

    /// <summary>
    /// Increase and send the analytics of a given event
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="eventCount"></param>
    public static void IncreaseAnalytics(string eventName, ref int eventCount) {
        eventCount++;
        Analytics.CustomEvent(eventName);

        Dictionary<string, object> analyticsData = new Dictionary<string, object>();
        analyticsData.Add(eventName, eventCount);
        Analytics.CustomEvent(eventName, analyticsData);
    }

    /// <summary>
    /// Increase the analytics of the 1st game over event
    /// </summary>
    public static void Increase1stGameOverAnalytics() {
        IncreaseAnalytics(eventCoinsLeft1stGameOver, ref intCoinsLeft1stGameOver);
        IncreaseAnalytics(eventHammersLeft1stGameOver, ref intHammersLeft1stGameOver);
        IncreaseAnalytics(eventBank1stGameOver, ref intBank1stGameOver);
        IncreaseAnalytics(eventFirstGameOverCount, ref intFirstGameOverCount);
    }

    /// <summary>
    /// Increase the analytics of the 1st game over event
    /// </summary>
    public static void Increase2ndGameOverAnalytics() {
        IncreaseAnalytics(eventRetryCount, ref intRetryCount);
        IncreaseAnalytics(eventCoinsLeft2stGameOver, ref intCoinsLeft2stGameOver);
        IncreaseAnalytics(eventHammersLeft2stGameOver, ref intHammersLeft2stGameOver);
        IncreaseAnalytics(eventSecondGameOverCount, ref intSecondGameOverCount);
    }

    /// <summary>
    /// Increase the analytics of the 1st game over event
    /// </summary>
    public static void IncreaseWinAnalytics() {
        IncreaseAnalytics(eventCoinsLeftWin, ref intCoinsLeftWin);
        IncreaseAnalytics(eventHammersLeftWin, ref intHammersLeftWin);
        IncreaseAnalytics(eventWinCount, ref intWinCount);
    }

}
