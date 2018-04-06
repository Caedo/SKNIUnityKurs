using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed {

	[RequireComponent(typeof(Rigidbody))]
	public class Bullet : MonoBehaviour {

		public float m_Speed; //Startowa prędkość pocisku

		private Rigidbody m_Rigidbody; //Referencja do komponentu Rigidbody 
		private AudioSource m_BoomAudio;
		protected virtual void Awake() {
			//Pobierz komponent
			m_Rigidbody = GetComponent<Rigidbody>();
			m_BoomAudio = GetComponentInChildren<AudioSource>();
		}

		protected virtual void Start() {
			//ustal prędkość pocisku
			m_Rigidbody.velocity = transform.forward * m_Speed;
		}

		//Funkcja wywoływana z CannonController. Zrobiona tylko po to, żeby pokazać,
		//że się da, równie dobrze można to przenieść do Start() i nikt by nie płakał
		public virtual void Initialize() {
			Destroy(gameObject, 5f);
		}

		protected virtual void OnCollisionEnter(Collision other) {
			if (m_BoomAudio) {
				m_BoomAudio.transform.parent = null;
				m_BoomAudio.Play();
				Destroy(m_BoomAudio.gameObject, m_BoomAudio.clip.length);
			}
			Destroy(gameObject);
		}
	}
}