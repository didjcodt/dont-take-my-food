using System.Collections;

using UnityEngine;

public class PlayerController: MonoBehaviour {

	// Set by Unity
	public float speed;

	private Rigidbody2D rb2d;

	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
	}

	public void Move(Vector2 mvt) {
		rb2d.AddForce(speed * mvt, ForceMode2D.Impulse);
	}
}
