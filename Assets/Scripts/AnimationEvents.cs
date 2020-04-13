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
    /// Play the sound effect of the animation
    /// </summary>
    public void PlaySoundEffect() { 
        if (audioSource != null) {
            audioSource.Play();
        }
    }

    /// <summary>
    /// Activate a panel
    /// </summary>
    public void ActivatePanel() {
        while (audioSource.isPlaying) { }
        panelToActivate.SetActive(true);
        gameObject.SetActive(false);
    }

}
