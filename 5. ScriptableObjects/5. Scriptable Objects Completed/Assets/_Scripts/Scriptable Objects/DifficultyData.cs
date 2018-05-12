using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnData {
	public Completed.EnemyHealth enemyPrefab;
	public float spawnTime;
}

[CreateAssetMenu]
public class DifficultyData : ScriptableObject {

	public List<EnemySpawnData> spawnData;

}