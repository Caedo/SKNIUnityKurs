using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed {
	public class LivingEntity : MonoBehaviour {
		public int m_StartingHealth;
		public int CurrentHealth { get; protected set; }

		public AudioClip m_DeathClip;

		protected Animator m_Anim;
		protected AudioSource m_Audio;
		protected bool m_IsDead;

		protected virtual void Awake() {
			m_Anim = GetComponent<Animator>();
			m_Audio = GetComponent<AudioSource>();

			CurrentHealth = m_StartingHealth;
		}

		public virtual void TakeDamage(int amount, Vector3? hitPoint = null) {

			CurrentHealth -= amount;
			m_Audio.Play();

			if (CurrentHealth <= 0 && !m_IsDead) {
				Death();
			}
		}

		protected virtual void Death() {
			m_IsDead = true;

			m_Audio.clip = m_DeathClip;
			m_Audio.Play();
		}
	}
}