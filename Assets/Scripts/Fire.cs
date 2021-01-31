using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fire : MonoBehaviour {
	// Set in Unity
	public float fireCooldown = 0f;
	public float bulletSpeed = 0f;
	public GameObject bulletPrefab = null;
	public float selfDestructTimer = 0f;

	// Internals
	private float timeUntilNextFire = 0f;
	private bool shouldShoot = false;
	private Vector3 shootPoint = new Vector3();

	void Update() {
		selfDestructTimer -= Time.deltaTime;
		if(selfDestructTimer < 0f) Destroy(gameObject);

		if(timeUntilNextFire >= 0) {
			timeUntilNextFire -= Time.deltaTime;
			return;
		}

		// From here we're always after the cooldown period. Reset only wheen shooting
		if(shouldShoot) {
			timeUntilNextFire = fireCooldown;
			var bullet = Instantiate(bulletPrefab,
					new Vector3(transform.position.x, transform.position.y, 0),
					transform.rotation);
			bullet.GetComponent<Rigidbody2D>().AddForce(bulletSpeed * (shootPoint - transform.position));
		}
	}

	private void OnTriggerStay2D(Collider2D collider) {
		if(collider.gameObject.tag == "Badboie") {
			shootPoint = collider.gameObject.transform.position;
			shouldShoot = true;
		}
	}
}
