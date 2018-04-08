using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TasksCompleted {
	public class PauseMenuController : MonoBehaviour {
		public GameObject m_PausePanel;

		private float m_StartFixedDeltaTime;
		private bool m_MenuActive = false;

		private void Start() {
			m_StartFixedDeltaTime = Time.fixedDeltaTime;
		}

		void Update() {
			if (Input.GetKeyDown(KeyCode.Escape)) {
				if (m_MenuActive) {
					HidePausePanel();
				} else {
					ShowPausePanel();
				}
			}
		}

		public void ShowPausePanel() {
			m_MenuActive = true;
			m_PausePanel.SetActive(true);
			Time.timeScale = 0;
			Time.fixedDeltaTime = 0;
		}

		public void HidePausePanel() {
			m_MenuActive = false;			
			m_PausePanel.SetActive(false);
			Time.timeScale = 1;
			Time.fixedDeltaTime = m_StartFixedDeltaTime;
		}

		public void BackToMenu(int sceneIndex) {
			Time.timeScale = 1;
			Time.fixedDeltaTime = m_StartFixedDeltaTime;
			
			SceneManager.LoadScene(sceneIndex);
		}
	}
}