using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functions for animation events
/// </summary>
public class AnimationEvents : MonoBehaviour {

    public GameObject panelToActivate;
    public AudioSource audioSource;

    /// <summary>
    /// Activate a panel
    /// </summary>
    public void ActivatePanel() {
        panelToActivate.SetActive(true);
        gameObject.SetActive(false);
        if (audioSource != null) {
            audioSource.Play();
        }
    }

}
