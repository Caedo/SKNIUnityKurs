using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed {
	public class TankController : MonoBehaviour {

		public float m_Speed; //Prędkość poruszania czołgu

		private Transform m_Camera; //Referencja do głównej kamery, która odpowiada za kierunek poruszania się
		private Rigidbody m_Rigidbody; //"Ciało sztywne" naszego czołgu
		private Quaternion m_TargetRotation; //Docelowa rotacja obiektu

		private void Awake() {
			//Inicjalizacja zmiennych
			m_Camera = Camera.main.transform;
			m_Rigidbody = GetComponent<Rigidbody>();
		}

		private void Update() {
			//ustalenie rotacji czołgu funkcją Slerp (Spherical Interpolation)
			transform.rotation = Quaternion.Slerp(transform.rotation, m_TargetRotation, 0.1f);
		}

		void FixedUpdate() {
			//Pobranie wejścia z klawiatury (lub innego urządzenia)
			float h = Input.GetAxisRaw("Horizontal");
			float v = Input.GetAxisRaw("Vertical");

			//rzutowanie wektora "forward" głównej kamery na płaszczyznę XZ,
			//Dzięki temu możemy w łatwy sposób ustalić w jakim kierunku mamy poruszyć czołgiem
			Vector3 m_CamForward = Vector3.Scale(m_Camera.forward, new Vector3(1, 0, 1)).normalized;
			Vector3 moveVelocity = (m_CamForward * v + m_Camera.right * h).normalized * m_Speed;

			//Jeżeli chcieliśmy się poruszyć w tej klatce to ustal decelową rotacje
			//Bez ifa czołg wracałby zawsze do rotacji domyślnej 
			if (moveVelocity != Vector3.zero) {
				m_TargetRotation = Quaternion.LookRotation(moveVelocity);
			}
			
			//ostatecznie ustalenie prędkości ciała
			m_Rigidbody.velocity = moveVelocity;			
		}
	}
}