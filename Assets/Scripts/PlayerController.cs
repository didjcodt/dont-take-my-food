using System.Collections;

using UnityEngine;

public class PlayerController: MonoBehaviour {

	// Set by Unity
	public float speed;

	private Rigidbody2D rb2d;
	private Animator anim;

	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void FixedUpdate() {
		Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

		var velocity = rb2d.velocity;
		anim.SetBool("isWalking", velocity.magnitude > 0.1f);
		anim.SetFloat("x", velocity.x);
		anim.SetFloat("y", velocity.y);
	}

	public void Move(Vector2 mvt) {
		rb2d.AddForce(speed * mvt, ForceMode2D.Impulse);
	}
}
