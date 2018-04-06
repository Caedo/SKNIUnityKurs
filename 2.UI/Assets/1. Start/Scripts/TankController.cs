using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Start {
	public class TankController : MonoBehaviour {

		public float m_Speed; //Prędkość poruszania czołgu
		public float m_TurboSpeed; //Prędkość podczas turbo
		public float m_TurboTime; //Czas trwania turbo
		public float m_TurboCooldown; //Cooldown trybu turbo
		public float m_RotationSpeed; //Prędkość rotacji

		private Rigidbody m_Rigidbody; //"Ciało sztywne" naszego czołgu
		private bool m_TurboActive; //Czy tyrbo jest aktywne
		private bool m_CanActiveTurbo = true; //Czy można aktywować turbo

		private void Awake() {
			//Inicjalizacja zmiennych
			m_Rigidbody = GetComponent<Rigidbody>();
		}

		private void Update() {
			//Jeżeli został naciśnięty lewy shift i możemy aktywować turbo...
			if (Input.GetKeyDown(KeyCode.LeftShift) && m_CanActiveTurbo) {

				//Wystartuj korutyne HandleTurbo()
				StartCoroutine(HandleTurbo());
			}
		}

		IEnumerator HandleTurbo() {

			//ustaw flagi: turbo jest aktywne i nie możemy go aktywować ponownie
			m_TurboActive = true;
			m_CanActiveTurbo = false;

			//poczekaj czas trwania...
			yield return new WaitForSeconds(m_TurboTime);

			//następnie ustaw flagę: turbo nie jest aktywne
			m_TurboActive = false;

			//przeczekaj cooldown...
			yield return new WaitForSeconds(m_TurboCooldown);

			//i ustaw flagę: można aktywować turbo
			m_CanActiveTurbo = true;
		}

		void FixedUpdate() {
			//Pobranie wejścia z klawiatury (lub innego urządzenia)
			float h = Input.GetAxisRaw("Horizontal");
			float v = Input.GetAxisRaw("Vertical");

			//ustalenie prędkości do przodu, jeżeli jest aktywne turbo, użyj tej prędkości
			Vector3 forwardVel = transform.forward * v * (m_TurboActive ? m_TurboSpeed : m_Speed);
			//Ustalenie zmiany rotacji w stopniach/sek
			//użyto kątów Eulera zapisanych w obiekcie klasy Vector3
			//Dla poruszania w tył rotacja jest odwrócona - bardziej intuicyjne
			Vector3 rotation = transform.up * h * m_RotationSpeed * Time.deltaTime * Mathf.Sign(v);

			//przypisanie prędkości
			m_Rigidbody.velocity = forwardVel;

			//Zmiana rotacji. Funkcja MoveRotation oczekuje akutalnej rotacji, więc
			//musimy podać aktualną rotację + zmianę rotacji. Mnożenie kwaternionów odpowiada
			//dodawaniu rotacji (chyba, nie jestem matematykiem :<)
			m_Rigidbody.MoveRotation(m_Rigidbody.rotation * Quaternion.Euler(rotation));
		}
	}
}