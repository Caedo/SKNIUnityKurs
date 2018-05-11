using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public ToggleGroup m_Group;

	public void StartGame() {
		string name = m_Group.ActiveToggles().FirstOrDefault().name;
		int diffIndex = 0;

		switch (name) {
			case "Easy":
			diffIndex = 0;
				break;
			case "Normal":
			diffIndex = 1;
				break;
			case "Hard":
			diffIndex = 2;			
				break;
		}

		Debug.Log(diffIndex);
	}
}