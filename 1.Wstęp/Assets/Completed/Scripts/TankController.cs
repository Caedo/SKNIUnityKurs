using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed {
	public class TankController : MonoBehaviour {
		
		public float m_Speed;

		private Transform m_Camera;
		private Rigidbody m_Rigidbody;

		private void Awake() {
			m_Camera = Camera.main.transform;
			m_Rigidbody = GetComponent<Rigidbody>();
		}

		void FixedUpdate() {
			var h = Input.GetAxisRaw("Horizontal");
			var v = Input.GetAxisRaw("Vertical");

			var m_CamForward = Vector3.Scale(m_Camera.forward, new Vector3(1, 0, 1)).normalized;
			Vector3 moveDelta = m_CamForward * v + m_Camera.right * h;
			moveDelta *= m_Speed;

			m_Rigidbody.velocity = moveDelta;
		}
	}
}