using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TasksCompleted {
	public class TurboUI : MonoBehaviour {

		public TankController m_PlayerTank;

		public Color m_TurboReadyColor;
		public Color m_TurboActiveColor;
		public Color m_TurboCooldownColor;

		public Image m_TurboImage;

		private void Awake() {
			m_PlayerTank.OnTurboStateChanged += ChangeImageColor;
		}

		void ChangeImageColor(TankController.TurboState state) {
			switch (state) {
				case TankController.TurboState.Ready:
					m_TurboImage.color = m_TurboReadyColor;
					break;

				case TankController.TurboState.Active:
					m_TurboImage.color = m_TurboActiveColor;
					break;

				case TankController.TurboState.Cooldown:
					m_TurboImage.color = m_TurboCooldownColor;
					break;
			}
		}
	}
}