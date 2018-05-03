using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Completed {
	public class HealthUIManager : MonoBehaviour {
		public Slider healthSlider; // Reference to the UI's health bar.
		public Image damageImage; // Reference to an image to flash on the screen on being hurt.
		public float flashSpeed = 5f; // The speed the damageImage will fade at.
		public Color flashColour = new Color(1f, 0f, 0f, 0.1f); // The colour the damageImage is set to, to flash

		public PlayerHealth m_PlayerHealth;

		bool damaged;

		private void Awake() {
			m_PlayerHealth.OnPlayerHit += OnPlayerHit;
		}

		void OnPlayerHit() { 
			damaged = true;

			healthSlider.value = (float)m_PlayerHealth.CurrentHealth / m_PlayerHealth.m_StartingHealth;
		}

		void Update() {
			// If the player has just been damaged...
			if (damaged) {
				// ... set the colour of the damageImage to the flash colour.
				damageImage.color = flashColour;
			}
			// Otherwise...
			else {
				// ... transition the colour back to clear.
				damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
			}

			// Reset the damaged flag.
			damaged = false;
		}
	}
}