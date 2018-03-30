using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed {
	public class CannonController : MonoBehaviour {

		public enum FireType { Bullet, Raycast }

		public FireType m_FireType;
		public LayerMask m_RayMask;
		public float m_BulletsPerSecond;
		public Transform m_BulletSpawnPoint;
		public Bullet m_BulletPrefab;

		private float m_TimeBetweenBullets;
		private float m_Timer;

		private void Start() {
			m_TimeBetweenBullets = 1 / m_BulletsPerSecond;
		}

		private void Update() {
			m_Timer += Time.deltaTime;

			if(Input.GetKeyDown(KeyCode.Tab)){
				m_FireType = m_FireType == FireType.Bullet ? FireType.Raycast : FireType.Bullet;
			}

			if (Input.GetButton("Fire1") && m_Timer >= m_TimeBetweenBullets) {
				m_Timer = 0;

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
			Ray ray = new Ray(m_BulletSpawnPoint.position, m_BulletSpawnPoint.forward);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 150f, m_RayMask)) {
				Rigidbody otherBody = hit.collider.GetComponent<Rigidbody>();
				if (otherBody) {
					otherBody.AddForceAtPosition(ray.direction * 10f, hit.point, ForceMode.Impulse);
				}
			}
		}

		void FireBullet() {
			var bullet = Instantiate(m_BulletPrefab, m_BulletSpawnPoint.position, m_BulletSpawnPoint.rotation);
			bullet.Initialize();
		}
	}
}