using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TasksCompleted {
	public class DoNotDestroyOnLoad : MonoBehaviour {
		void Start() {
			DontDestroyOnLoad(gameObject);
		}
	}
}