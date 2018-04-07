using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed {

	[RequireComponent(typeof(Rigidbody))]
	public class Bullet : MonoBehaviour {

		public float m_Speed; //Startowa prędkość pocisku
		public AudioSource m_BoomAudio;

		private Rigidbody m_Rigidbody; //Referencja do komponentu Rigidbody 
		protected virtual void Awake() {
			//Pobierz komponent
			m_Rigidbody = GetComponent<Rigidbody>();
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

		//Osługa kolizji
		protected virtual void OnCollisionEnter(Collision other) {

			//Jeżeli mamy referencje do jakiegoś źródła dźwięku...
			if (m_BoomAudio) {
				//Tworzymy jego kopię...
				var spawned = Instantiate(m_BoomAudio, transform.position, transform.rotation);
				//I niszczymy ją po tym jak odtworzy całość klipu
				Destroy(spawned.gameObject, spawned.clip.length);
			} else {
				//W przeciwnym wypadku wypisujemy warning
				Debug.LogWarning("Bullet Script don't have Audio Prefab referenced");
			}
			//Na koniec niszczymy siebie
			Destroy(gameObject);
		}
	}
}