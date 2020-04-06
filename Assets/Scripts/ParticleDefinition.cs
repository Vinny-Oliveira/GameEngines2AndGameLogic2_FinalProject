using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name ID of the particle system
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class ParticleDefinition : MonoBehaviour {

    public string name_id = "default";
    public AudioSource audioSource;
    public AudioClip hitSound;

    /// <summary>
    /// Play a sound effect when the particle is triggered
    /// </summary>
    public void PlayHitSound() { 
        if (audioSource == null) {
            audioSource = GetComponent<AudioSource>();
        }
        audioSource.clip = hitSound;
        audioSource.Play();
    }

}