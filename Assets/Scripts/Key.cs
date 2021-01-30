using System.Collections;

using UnityEngine;

public class Key: MonoBehaviour {
	public enum KeyPress {
		Left,
		Right,
		Up,
		Down,
		Fire
	}

	// Set by Unity
	public PlayerController player = null;
	public float force = 0f;
	public KeyPress keyToPress = KeyPress.Left;
	public Sprite released = null;
	public Sprite pressed = null;

	// Internals
	private bool isTriggered;

	void Update() {
		if(isTriggered)
			gameObject.GetComponent<SpriteRenderer>().sprite = pressed;
		else
			gameObject.GetComponent<SpriteRenderer>().sprite = released;
	}

	void FixedUpdate() {
		if(!isTriggered) return;

		var mvt = new Vector2(0f, 0f);
		switch(keyToPress) {
			case KeyPress.Left:
				mvt = new Vector2(-1f, 0f);
				break;
			case KeyPress.Right:
				mvt = new Vector2(1f, 0f);
				break;
			case KeyPress.Up:
				mvt = new Vector2(0f, 1f);
				break;
			case KeyPress.Down:
				mvt = new Vector2(0f, -1f);
				break;
			case KeyPress.Fire:
				Debug.Log("NOT FIRING");
				break;
		};
		player.Move(force * mvt);
	}

	private void OnTriggerStay2D(Collider2D collider) {
		// Trigger key press only when the hammer presses it
		if(collider.gameObject.tag == "Badboie")
			isTriggered = collider.gameObject.GetComponent<Badboie>().hammerPressed;
	}

	private void OnTriggerExit2D(Collider2D collider) {
		if(collider.gameObject.tag == "Badboie")
			isTriggered = false;
	}
}