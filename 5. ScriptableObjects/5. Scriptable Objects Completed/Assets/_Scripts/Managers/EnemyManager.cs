using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed {
    public class EnemyManager : MonoBehaviour {

        public GameSettings m_GameSettings;
        public List<DifficultyData> m_DifficultyData;

        public PlayerHealth playerHealth; // Reference to the player's heatlh.
        // public GameObject enemy; // The enemy prefab to be spawned.
        // public float spawnTime = 3f; // How long between each spawn.
        public Transform[] spawnPoints; // An array of the spawn points this enemy can spawn from.

        DifficultyData m_CurrentDifficulty;

        void Start() {

#if UNITY_EDITOR
            if (GameSettingsManager.Instance) {
                m_CurrentDifficulty = m_DifficultyData[GameSettingsManager.Instance.DifficultyIndex];
            } else {
                m_CurrentDifficulty = m_DifficultyData[m_GameSettings.m_DifficultyIndex];
            }
#else
            m_CurrentDifficulty = m_DifficultyData[GameSettingsManager.Instance.DifficultyIndex];
#endif            

            for (int i = 0; i < m_CurrentDifficulty.spawnData.Count; i++) {
                StartCoroutine(SpawnEnemy(m_CurrentDifficulty.spawnData[i]));
            }

            playerHealth.OnPlayerDeath += OnPLayerDeath;
        }

        IEnumerator SpawnEnemy(EnemySpawnData data) {
            WaitForSeconds wait = new WaitForSeconds(data.spawnTime);

            while (true) {
                yield return wait;
                int index = Random.Range(0, spawnPoints.Length);
                Instantiate(data.enemyPrefab, spawnPoints[index].position, spawnPoints[index].rotation);
            }
        }

        void OnPLayerDeath() {
            StopAllCoroutines();
        }

        // void Spawn() {
        //     // If the player has no health left...
        //     if (playerHealth.CurrentHealth <= 0f) {
        //         // ... exit the function.
        //         return;
        //     }

        //     // Find a random index between zero and one less than the number of spawn points.
        //     int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //     // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        //     Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        // }
    }
}