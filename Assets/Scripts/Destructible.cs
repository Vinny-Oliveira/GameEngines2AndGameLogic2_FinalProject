using System.Collections;
using System.Collections.Generic;
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

    static List<ParticleSystem> listParticles = new List<ParticleSystem>();

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
        intHealth--;

        if (intHealth < 1) {
            gameObject.SetActive(false);
            DisableObject();
        }
    }

    /// <summary>
    /// Event to detect mouse of touch down
    /// </summary>
    private void OnMouseDown() {
#if UNITY_EDITOR
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
#elif UNITY_ANDROID
        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
            return;
        }
#endif  
        if (canDestroy) {
            DecreaseHealth();
            HammerManager.instance.HitAnObject();
        }
    }

    /// <summary>
    /// Award the player with an amount of coins defined in this destructible
    /// </summary>
    public virtual void DisableObject() {
        // Play particle system
        ParticlePooling();

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
        particleSystem.gameObject.SetActive(true);
        particleSystem.Play();
    }

    /// <summary>
    /// Object pooling for particle systems
    /// </summary>
    void ParticlePooling() { 
        // Check if there is a particle system in the destructibleSO
        if (destructible.particleSystem != null) {
            string myParticleName = destructible.particleSystem.GetComponent<ParticleDefinition>().name_id;
            bool isParticleFound = false;

            // Go through the particle list and compare IDs
            foreach (ParticleSystem particle in listParticles) { 
                if (particle.GetComponent<ParticleDefinition>().name_id == myParticleName) {
                    isParticleFound = true;
                    PlayParticle(particle);
                    break;
                }
            }

            // Instantiate a new particle and put it in the pooling list
            if (!isParticleFound) {
                ParticleSystem newParticle = Instantiate(destructible.particleSystem);
                listParticles.Add(newParticle);
                PlayParticle(newParticle);
            }
        }
    }
}
