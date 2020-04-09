using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGamePurchaser : MonoBehaviour {

    [Header("UI References")]
    public Button stdButton;
    public GameObject gameOverPurchaseBtn;
    public GameObject gameOverContinueBtn;
    public TextMeshProUGUI tmpProductCost;
    public TextMeshProUGUI tmpProductAmount;
    public TextMeshProUGUI tmpAmountBought;
    public TextMeshProUGUI tmpBankAmount;
    public GameObject hammerOptiosPanel;
    public GameObject thxPurchasePanel;
    
    [Header("Cost and Product")]
    public int cost;
    public int productAmount;

    const int MIN_TIMER = 10;

    /// <summary>
    /// Spend coins and gain hammers if the purchase was successful
    /// </summary>
    public void ConfirmPurchase() {
        //if (iapButton == null) {
        //    iapButton = GetComponent<IAPButton>();
        //}

        // Try to trade coins for hammers
        try {
            CoinManager.instance.SaveCoinsToBank(-cost); // may throw
            tmpBankAmount.text = CoinManager.instance.GetBank().ToString();
            HammerManager hammerManager = HammerManager.instance;
            hammerManager.PopulateHammerQueue(productAmount);

            // Give the user some more time if they are running short
            TimerManager timerManager = TimerManager.instance;
            if (timerManager.GetTimer() < MIN_TIMER) {
                timerManager.SetTimer(MIN_TIMER);
            }

            // Reset UI objects
            tmpAmountBought.text = productAmount.ToString();
            thxPurchasePanel.SetActive(true);
        
            PurchaseController[] purchaseControllers = hammerOptiosPanel.GetComponentsInChildren<PurchaseController>();
            foreach (PurchaseController controller in purchaseControllers) {
                //controller.TurnButtonOnOff();
            }

            gameOverPurchaseBtn.SetActive(false);
            gameOverContinueBtn.SetActive(true);
        } catch (System.InvalidOperationException ex) {
            Debug.Log(ex.Message);
        }
    }

    /// <summary>
    /// Check if the button should be interactable.
    /// It should be only if the cost of the product is less than what the player has.
    /// </summary>
    void TurnButtonOnOff() {
        if (stdButton == null) {
            stdButton = GetComponent<Button>();
        }

        stdButton.interactable = (cost <= CoinManager.instance.GetBank());
    }

    /// <summary>
    /// Check if the button should be interactable when it awakes
    /// </summary>
    private void OnEnable() {
        tmpProductCost.text = cost.ToString();
        tmpBankAmount.text = CoinManager.instance.GetBank().ToString();
        tmpProductAmount.text = "x" + productAmount.ToString();
        TurnButtonOnOff();
    }
}
