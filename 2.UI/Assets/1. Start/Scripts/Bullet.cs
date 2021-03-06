﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Start {

	[RequireComponent(typeof(Rigidbody))]
	public class Bullet : MonoBehaviour {

		public float m_Speed; //Startowa prędkość pocisku

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
	}
}