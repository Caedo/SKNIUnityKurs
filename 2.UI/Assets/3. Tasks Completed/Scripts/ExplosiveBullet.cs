using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TasksCompleted {
	public class ExplosiveBullet : Bullet {

		public float m_ExplosionRadius; //Promień eksplozji
		public float m_ExplosionForce; //Siła eksplozji

		//Obsługa kolizji - zmiana względem poprzedniego projektu,
		//Teraz używamy OnCollisionEnter, a nie OnTriggerEnter
		protected override void OnCollisionEnter(Collision other) {
			//Znajdź wszystkie collidery w promieniu eksplozji
			Collider[] colliders = Physics.OverlapSphere(transform.position, m_ExplosionRadius);

			//Dla każdego znalezionego collidera...
			foreach (Collider item in colliders)
			{
				//Sprawdź czy ma Rigidbody...
				Rigidbody body = item.GetComponent<Rigidbody>();
				//i jeżeli przypadkiem ma...
				if(body) {
					//przyłóż do niego siłę metodą AddExplosionForce
					body.AddExplosionForce(m_ExplosionForce, transform.position, m_ExplosionRadius, 0, ForceMode.Impulse);
				}
			}

			//Jeżeli skończyliśmy z eksplozją, resztę zostawiamy funkcji bazowej
			base.OnCollisionEnter(other);
		}
	}
}