using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TasksCompleted {
	public class ExplosiveBullet : Bullet {

		public float m_ExplosionRadius; //Promień eksplozji
		public float m_ExplosionForce; //Siła eksplozji

		//Ta funkcja jest wywoływana, jeżeli komponent Collider przetnie inny kolider, należący do innego obiektu
		//checkbox "Is Trigger" musi być zaznaczony w Inspektorze
		private void OnTriggerEnter(Collider other) {
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

			//na samym końcu zniszcz samego siebie
			Destroy(gameObject);
		}
	}
}