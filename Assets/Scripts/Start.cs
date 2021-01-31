using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class Start: MonoBehaviour {
	// Set by Unity
	public ScenesData sd = null;
	public Button button = null;

	void Update() {
		if(Input.GetButton("Jump"))
			button.onClick.Invoke();
	}
}
