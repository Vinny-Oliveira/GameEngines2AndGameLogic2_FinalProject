using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions for animation events
/// </summary>
public class AnimationEvents : MonoBehaviour {

    public GameObject panel;

    /// <summary>
    /// Activate a panel
    /// </summary>
    public void ActivatePanel() {
        panel.SetActive(true);
    }

}
