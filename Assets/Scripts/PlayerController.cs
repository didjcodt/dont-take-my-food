using System.Collections;

using UnityEngine;

public class PlayerController: MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2d;

	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() {
		Vector2 movement = new Vector2(
				Input.GetAxis("Horizontal"),
				Input.GetAxis("Vertical"));
		rb2d.AddForce(movement * speed);
	}
}
