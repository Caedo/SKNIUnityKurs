using UnityEngine;

namespace Completed {
    public class GameOverManager : MonoBehaviour {
        public PlayerHealth playerHealth; // Reference to the player's health.

        Animator anim; // Reference to the animator component.

        void Awake() {
            // Set up the reference.
            anim = GetComponent<Animator>();
            playerHealth.OnPlayerDeath += OnPlayerDeath;
        }

        void OnPlayerDeath() {
            anim.SetTrigger("GameOver");
        }
    }
}