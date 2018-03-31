using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TasksCompleted {
	public class CannonController : MonoBehaviour {

		//Enum Określający typ strzału
		public enum FireType { Bullet, Raycast }

		public FireType m_FireType; //Obiekt powyższego enuma
		public LayerMask m_RayMask; //Maska warstwy, w którą możemy trafić Raycastem
		public float m_BulletsPerSecond; //ilość pocisków na sekunde
		public Transform m_BulletSpawnPoint; //Punkt w którym tworzymy pocisk
		public Bullet m_BulletPrefab; //Prefab pocisku

		private float m_TimeBetweenBullets; //czas, jaki musimy odczekać pomiędzy strzałem pocisków
		private float m_Timer; //timer... Zawsze zeruj!

		private void Start() {
			//Obliczenie czasu pomiędzy pociskami
			m_TimeBetweenBullets = 1 / m_BulletsPerSecond;
		}

		private void Update() {
			//zwiększenie wartości timera o czas od ostatniej klatki
			m_Timer += Time.deltaTime;

			//Jeżeli został wciśnięty Tab zmień tryb strzału
			if (Input.GetKeyDown(KeyCode.Tab)) {
				m_FireType = m_FireType == FireType.Bullet ? FireType.Raycast : FireType.Bullet;
			}

			//Jeżeli przypadkiem tak się zdarzyło, że Fire1 (domyślnie PPM lub ctrl i pewnie kilka innyh)
			//oraz timer jest większy od zadanego czasu wystrzel pocisk w zależności od aktualnego trybu
			if (Input.GetButton("Fire1") && m_Timer >= m_TimeBetweenBullets) {
				m_Timer = 0; //ZAWSZE ZERUJ!!

				switch (m_FireType) {
					case FireType.Bullet:
						FireBullet();
						break;
					case FireType.Raycast:
						FireRaycast();
						break;
				}

			}
		}

		private void FireRaycast() {
			//struktura zawierająca informacje o promieniu
			Ray ray = new Ray(m_BulletSpawnPoint.position, m_BulletSpawnPoint.forward);

			//Struktura zawierająca informacje o trafieniu
			RaycastHit hit;

			//Jeżeli w coś trafiliśmy...
			if (Physics.Raycast(ray, out hit, 150f, m_RayMask)) {
				//Sprawdź, czy cel ma komponent Rigidbody...
				Rigidbody otherBody = hit.collider.GetComponent<Rigidbody>();
				//i jeżeli ma...
				if (otherBody) {
					//To zadziałaj na niego siłą
					otherBody.AddForceAtPosition(ray.direction * 10f, hit.point, ForceMode.Impulse);
				}
			}
		}

		void FireBullet() {
			//Stwórz pocisk na określonej przez m_BulletSpawnPoint pozycji i rotacji
			var bullet = Instantiate(m_BulletPrefab, m_BulletSpawnPoint.position, m_BulletSpawnPoint.rotation);
			bullet.Initialize();
		}

		//Ta funkcja jest wywoływana w momencie zmiany jakiejś wartości w Inspektorze, także podczas Play Mode
		private void OnValidate() {
			m_TimeBetweenBullets = 1 / m_BulletsPerSecond;
		}
	}
}