using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Completed {

	[RequireComponent(typeof(Rigidbody))]
	public class Bullet : MonoBehaviour {

		public float m_Speed;

		private Rigidbody m_Rigidbody;
		private void Awake() {
			m_Rigidbody = GetComponent<Rigidbody>();
		}

		private void Start() {
			m_Rigidbody.velocity = transform.forward * m_Speed;
		}

		public void Initialize(){
			Destroy(gameObject, 5f);
		}
	}
}