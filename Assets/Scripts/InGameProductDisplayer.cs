using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[System.Serializable]
public enum Product { 
    HAMMER = 1,
    TEN_SEC = 10,
    TWENTY_SEC = 20
}

public class InGameProductDisplayer : MonoBehaviour {

    [Header("Product Details")]
    public Product product;
    public int intPrice;
    public TextMeshProUGUI tmpPrice;

    [Header("UI Control")]
    const int MAX_AMOUNT = 9;
    public TextMeshProUGUI tmpProductAmount;
    int intProductAmount;
    public Button btnMinus;
    public Button btnPlus;

    /// <summary>
    /// Get the amount of that particular product
    /// </summary>
    /// <returns></returns>
    public int GetAmount() {
        return intProductAmount;
    }

    /// <summary>
    /// Get the amount of that particular product
    /// </summary>
    /// <returns></returns>
    public void SetAmount(int newAmount) {
        intProductAmount = newAmount;
    }

    /// <summary>
    /// Update the value fields when the panel is enabled
    /// </summary>
    private void OnEnable() {
        tmpPrice.text = intPrice.ToString();
        //tmpProductAmount.text = "0";
        btnMinus.interactable = false;
    }

    /// <summary>
    /// Increse the amount of the product bought by one if it is less than the maximum
    /// </summary>
    public void IncreaseAmount() {
        if (Int32.TryParse(tmpProductAmount.text, out intProductAmount)) {
            if (intProductAmount < MAX_AMOUNT) { 
                intProductAmount++;
                tmpProductAmount.text = intProductAmount.ToString();
                btnMinus.interactable = true;
            }

            if (intProductAmount > MAX_AMOUNT - 1) {
                tmpProductAmount.text = MAX_AMOUNT.ToString();
                btnPlus.interactable = false;
            }
        } else {
            tmpProductAmount.text = "0";
        }
    }

    /// <summary>
    /// Decrease the amount of the product bought by one if it is more than zero
    /// </summary>
    public void DecreaseAmount() {
        if (Int32.TryParse(tmpProductAmount.text, out intProductAmount) && (intProductAmount > 0)) {
            intProductAmount--;
            tmpProductAmount.text = intProductAmount.ToString();
            btnPlus.interactable = true;

            if (intProductAmount < 1) {
                btnMinus.interactable = false;
            }
        } else {
            tmpProductAmount.text = "0";
            btnMinus.interactable = false;
        }
    }
}
