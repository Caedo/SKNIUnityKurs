using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TasksCompleted {
	public class MainAudioSingleton : MonoBehaviour {

		public static MainAudioSingleton Instance { get; private set; }

		private void Awake() {
			if(Instance != null) {
				DestroyImmediate(gameObject);
				return;
			}

			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
}