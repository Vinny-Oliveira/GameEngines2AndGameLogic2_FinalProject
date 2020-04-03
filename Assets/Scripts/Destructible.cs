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
        if (destructible.particleSystem != null) {
            string myParticle = destructible.particleSystem.GetComponent<ParticleDefinition>().name_id;
            
            foreach (ParticleDefinition particleDef in ParticlePool.instance.particleSystems) { 
                if (particleDef.name_id == myParticle) { // Compare IDs

                    if (particleDef.particle == null) {
                        particleDef.AttachSelf();
                    }

                    particleDef.transform.position = transform.position;
                    particleDef.gameObject.SetActive(true);
                    particleDef.particle.Play();
                    break;
                }
            }
        }

        // Update variables
        TimerManager.instance.BoostTimer(destructible.intTimeBooster);
        CoinManager.instance.GainCoins(destructible.intCoinValue);
    }
}
