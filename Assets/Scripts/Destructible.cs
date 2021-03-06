﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// Base class that models all the objects that are destructible by game mechanics
/// </summary>
public abstract class Destructible : MonoBehaviour {

    [SerializeField]
    DestructibleSO destructible;

    int intHealth;
    bool canDestroy = false;

    static List<ParticleSystem> destructionParticles = new List<ParticleSystem>();
    static List<ParticleSystem> damageParticles = new List<ParticleSystem>();

    /// <summary>
    /// Reset health according to value of the destructable SO
    /// </summary>
    public void ResetHealth() {
        canDestroy = true;
        intHealth = destructible.intHealth;
    }

    /// <summary>
    /// Decrease health of the destructable object
    /// </summary>
    public virtual void DecreaseHealth() {
        if (canDestroy) { 
            intHealth--;
            ParticlePooling(ref damageParticles, destructible.particleDamage);

            if (intHealth < 1) {
                gameObject.SetActive(false);
                DisableObject();
            }
            HammerManager.instance.HitAnObject();
        }
    }

    /// <summary>
    /// Decrease the ojbect's health if it is clicked/touched
    /// </summary>
    private void OnMouseDown() {
        if (!IsPointerOverUIObject()) {
            DecreaseHealth();
        }
    }

    /// <summary>
    /// Check if the mouse or touch is over a UI object
    /// </summary>
    /// <returns></returns>
    bool IsPointerOverUIObject() {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        Vector2 position;
#if UNITY_EDITOR
        position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
#elif UNITY_ANDROID
        position = Input.GetTouch(0).position;
#endif
        eventDataCurrentPosition.position = position;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return (results.Count > 0);
    }

    /// <summary>
    /// Award the player with an amount of coins defined in this destructible
    /// </summary>
    public virtual void DisableObject() {
        // Play particle system
        ParticlePooling(ref destructionParticles, destructible.particleDestruction);

        // Update variables
        TimerManager.instance.BoostTimer(destructible.intTimeBooster);
        CoinManager.instance.GainCoins(destructible.intCoinValue);
    }

    /// <summary>
    /// Play a particle system on where this object is
    /// </summary>
    /// <param name="particleSystem"></param>
    void PlayParticle(ParticleSystem particleSystem) {
        particleSystem.transform.position = transform.position;
        particleSystem.transform.rotation = transform.rotation;
        particleSystem.gameObject.SetActive(true);
        particleSystem.Play();
        particleSystem.GetComponent<ParticleDefinition>().PlayHitSound();
    }

    /// <summary>
    /// Object pooling for particle systems
    /// </summary>
    void ParticlePooling(ref List<ParticleSystem> listParticles, ParticleSystem particleType) { 
        // Check if there is a particle system in the destructibleSO
        if (particleType != null) {
            string myParticleName = particleType.GetComponent<ParticleDefinition>().name_id;
            
            // Go through the particle list and compare IDs
            ParticleSystem particle = listParticles.Find(x => (x != null && x.GetComponent<ParticleDefinition>().name_id == myParticleName));

            // Instantiate a new particle if none is found and then play the particle
            if (particle == null) {
                particle = Instantiate(particleType);
                listParticles.Add(particle);
            }
            PlayParticle(particle);
        }
    }
}
