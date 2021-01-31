using System.Collections;

using UnityEngine;

public class PlayerController: MonoBehaviour {

	// Set by Unity
	public float speed = 0f;
	public float turretCooldown = 0f;
	public GameObject turretPrefab = null;

	// Internals
	private Rigidbody2D rb2d;
	private Animator anim;
	public float timeToNextTurret { get; private set; }

	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update() {
		if(timeToNextTurret > 0f) timeToNextTurret -= Time.deltaTime;

		if(Input.GetButton("Fire1"))
			SpawnTurret();
	}

	void FixedUpdate() {
		Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

		var velocity = rb2d.velocity;
		anim.SetBool("isWalking", velocity.magnitude > 0.1f);
		anim.SetFloat("x", velocity.x);
		anim.SetFloat("y", velocity.y);
	}

	public void SpawnTurret() {
		// Only spawn on cooldown
		if(timeToNextTurret > 0f) return;

		Instantiate(turretPrefab,
				new Vector3(transform.position.x, transform.position.y, 10),
				transform.rotation);
		timeToNextTurret = turretCooldown;
	}

	public void Move(Vector2 mvt) {
		rb2d.AddForce(speed * mvt, ForceMode2D.Impulse);
	}
}
