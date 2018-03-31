using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TasksCompleted {

	[RequireComponent(typeof(Rigidbody))]
	public class Bullet : MonoBehaviour {

		public float m_Speed; //Startowa prędkość pocisku

		private Rigidbody m_Rigidbody; //Referencja do komponentu Rigidbody 
		private void Awake() {
			//Pobierz komponent
			m_Rigidbody = GetComponent<Rigidbody>();
		}

		private void Start() {
			//ustal prędkość pocisku
			m_Rigidbody.velocity = transform.forward * m_Speed;
		}

		//Funkcja wywoływana z CannonController. Zrobiona tylko po to, żeby pokazać,
		//że się da, równie dobrze można to przenieść do Start() i nikt by nie płakał
		public void Initialize() {
			Destroy(gameObject, 5f);
		}
	}
}