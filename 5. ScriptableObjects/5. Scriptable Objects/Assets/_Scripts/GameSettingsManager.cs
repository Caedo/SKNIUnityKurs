using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour {

	public static GameSettingsManager Instance { get; private set; }

	public int DifficultyIndex { get; set; }

	private void Awake() {
		if (Instance != null) {
			DestroyImmediate(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
}