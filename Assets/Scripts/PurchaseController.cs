using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using TMPro;

public class PurchaseController : MonoBehaviour {

    public IAPButton iapButton;
    public Button stdButton;
    public GameObject gameOverPurchaseBtn;
    public GameObject gameOverContinueBtn;
    public TextMeshProUGUI tmpProductAmount;
    public GameObject thxPurchasePanel;
    public int cost;
    public int productAmount;

    //static Dictionary<string, Tuple<int, int>> productList = BuildProductList();

    ///// <summary>
    ///// Build the list of products
    ///// </summary>
    ///// <returns></returns>
    //static Dictionary<string, Tuple<int, int>> BuildProductList() {
    //    Dictionary<string, Tuple<int, int>> productList = new Dictionary<string, Tuple<int, int>>();
    //    productList.Add("com.wildspreadstudios.homewrecker.10coins2hammers", new Tuple<int, int>(10, 2));
    //    return productList;
    //}

    /// <summary>
    /// Spend coins and gain hammers if the purchase was successful
    /// </summary>
    public void ConfirmPurchase() {
        if (iapButton == null) {
            iapButton = GetComponent<IAPButton>();
        }

        //string product = iapButton.productId;
        //Tuple<int, int> values;

        //if (productList.TryGetValue(product, out values)) { 
        //CoinManager.instance.SaveCoinsToBank(-values.Item1);
        CoinManager.instance.SaveCoinsToBank(-cost);
        HammerManager hammerManager = HammerManager.instance;
        //hammerManager.PopulateHammerQueue(values.Item2, hammerManager.intHammerHealth);
        hammerManager.PopulateHammerQueue(productAmount, hammerManager.intHammerHealth);
        //}

        tmpProductAmount.text = productAmount.ToString();
        thxPurchasePanel.SetActive(true);
        gameOverPurchaseBtn.SetActive(false);
        gameOverContinueBtn.SetActive(true);
        TurnButtonOnOff();
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
        TurnButtonOnOff();
    }
}
