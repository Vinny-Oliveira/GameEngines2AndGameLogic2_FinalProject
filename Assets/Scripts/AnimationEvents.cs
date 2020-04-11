using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions for animation events
/// </summary>
public class AnimationEvents : MonoBehaviour {

    public GameObject panelToActivate;

    /// <summary>
    /// Activate a panel
    /// </summary>
    public void ActivatePanel() {
        panelToActivate.SetActive(true);
    }

}
