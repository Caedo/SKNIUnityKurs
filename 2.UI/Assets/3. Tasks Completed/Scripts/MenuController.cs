using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TasksCompleted {
	public class MenuController : MonoBehaviour {

		[Header("Panels")]
		public GameObject m_MainPanel;
		public GameObject m_OptionsPanel;

		[Header("Audio")]
		public AudioMixer m_MainMixer;

		[Header("Sliders")]
		public Slider m_MasterSlider;
		public Slider m_MusicSlider;
		public Slider m_EffectsSlider;

		private void Start() {
			float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1);
			float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);
			float effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 1);
			
			m_MasterSlider.value = masterVolume;
			m_MusicSlider.value = musicVolume;
			m_EffectsSlider.value = effectsVolume;

			SetMasterVolume(masterVolume);
			SetMusicVolume(musicVolume);
			SetEffectsVolume(effectsVolume);
		}

		public void ShowOptionsMenu() {
			m_MainPanel.SetActive(false);
			m_OptionsPanel.SetActive(true);
		}

		public void ShowMainMenu() {
			m_MainPanel.SetActive(true);
			m_OptionsPanel.SetActive(false);
		}

		public void SetMasterVolume(float value) {
			SetVolume("MasterVolume", value);
		}

		public void SetMusicVolume(float value) {
			SetVolume("MusicVolume", value);
		}

		public void SetEffectsVolume(float value) {
			SetVolume("EffectsVolume", value);
		}

		void SetVolume(string name, float value) {
			float volume = Mathf.Lerp(-40, 0, value);
			if (value == 0) {
				volume = -80f;
			}

			m_MainMixer.SetFloat(name, volume);
			PlayerPrefs.SetFloat(name, value);
			PlayerPrefs.Save();
		}

		public void StartGame() {
			SceneManager.LoadScene(3);
		}
	}
}