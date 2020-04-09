using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameProductDisplayer : MonoBehaviour {

    [Header("Product Details")]
    public Image imgProduct;
    public int intPrice;
    public TextMeshProUGUI tmpPrice;

    [Header("UI Control")]
    public TextMeshProUGUI tmpAmountToBuy;
    public Button btnMinus;
    public Button btnPlus;
}
