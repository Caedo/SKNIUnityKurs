using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Completed {
    public class PlayerHealth : LivingEntity {
        PlayerMovement playerMovement; // Reference to the player's movement.
        PlayerShooting playerShooting; // Reference to the PlayerShooting script.    

        public event System.Action OnPlayerHit;
        public event System.Action OnPlayerDeath;

        protected override void Awake() {
            base.Awake();

            playerMovement = GetComponent<PlayerMovement>();
            playerShooting = GetComponentInChildren<PlayerShooting>();
        }

        public override void TakeDamage(int amount, Vector3? hitPoint = null) {
            base.TakeDamage(amount, hitPoint);

            if(OnPlayerHit != null) {
                OnPlayerHit();
            }
        }

        protected override void Death() {
            base.Death();

            // Turn off any remaining shooting effects.
            playerShooting.DisableEffects();

            // Tell the animator that the player is dead.
            m_Anim.SetTrigger("Die");

            // Turn off the movement and shooting scripts.
            playerMovement.enabled = false;
            playerShooting.enabled = false;

            if(OnPlayerDeath != null) {
                OnPlayerDeath();
            }
        }

        public void RestartLevel() {
            // Reload the level that is currently loaded.
            SceneManager.LoadScene(0);
        }
    }
}