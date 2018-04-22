using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Completed {
    public class ScoreManager : MonoBehaviour {
        private int score; // The player's score.

        public Text text; // Reference to the Text component.

        void Awake() {
            EnemyHealth.OnEnemyDeath += OnEnemyDeath;
        }

        void OnEnemyDeath(EnemyHealth health) {
            score += health.scoreValue;
            text.text = "Score: " + score;
        }

        private void OnDisable() {
            EnemyHealth.OnEnemyDeath -= OnEnemyDeath;
        }
    }
}