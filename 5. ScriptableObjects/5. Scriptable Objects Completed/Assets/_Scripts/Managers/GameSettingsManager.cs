using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour {

	[HideInInspector]
	public GameSettings m_GameSettings;

	public static GameSettingsManager Instance { get; private set; }

	public int DifficultyIndex {
		get {
			return m_GameSettings.m_DifficultyIndex;
		}
		set {
			m_GameSettings.m_DifficultyIndex = value;
		}
	}

	private void Awake() {
		if (Instance != null) {
			DestroyImmediate(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);

		m_GameSettings = ScriptableObject.CreateInstance<GameSettings>();
	}
}