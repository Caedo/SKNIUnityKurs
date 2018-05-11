using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

	public float m_MinShowTime;
	public float m_MaxShowTime;

	public int m_HealAmount;

	[Header("Animation")]
	public float m_RotationSpeed;
	public Transform m_GraphicsTransform;

	private void Start() {
		gameObject.SetActive(false);
		Invoke("Refresh", Random.Range(m_MinShowTime, m_MaxShowTime));
	}

	private void Update() {
		m_GraphicsTransform.Rotate(Vector3.up, m_RotationSpeed * Time.deltaTime, Space.World);
	}

	void Refresh() {
		gameObject.SetActive(true);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			Completed.PlayerHealth health = other.GetComponent<Completed.PlayerHealth>();
			if (health.Heal(m_HealAmount)) {
				gameObject.SetActive(false);
				Invoke("Refresh", Random.Range(m_MinShowTime, m_MaxShowTime));
			}
		}
	}

}