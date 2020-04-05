using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class AdsForRewards : MonoBehaviour, IUnityAdsListener
{

#if UNITY_EDITOR
    string gameId = "1234567";
#elif UNITY_IOS
    private string gameId = "3533493";
#elif UNITY_ANDROID
    private string gameId = "3533492";
#endif

    public Button btnAdsForCoins;
    public string myPlacementId = "rewardedVideo";
    public int intRewardedCoins;

    void Start() {
        if (btnAdsForCoins == null) {
            btnAdsForCoins = GetComponent<Button>();
        }

        // Set interactivity to be dependent on the Placement’s status:
        btnAdsForCoins.interactable = Advertisement.IsReady(myPlacementId);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }

    // Implement a function for showing a rewarded video ad:
    public void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            btnAdsForCoins.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            // Reward the user for watching the ad to completion.
            CoinManager.instance.SaveCoinsToBank(intRewardedCoins);
            btnAdsForCoins.interactable = false; // Disable the ads for coins button
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}