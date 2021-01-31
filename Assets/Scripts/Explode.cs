using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Explode : MonoBehaviour {
	// Set by Unity
	public float selfDestructTimer = 0f;

	void Start() {
	}

	void Update() {
		selfDestructTimer -= Time.deltaTime;

		if(selfDestructTimer < 0f) {
			GetComponent<Animator>().SetTrigger("Explode");
		}
		if(selfDestructTimer < -0.5f) {
			var cs = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius);
			foreach(var c in cs) {
				if(c.gameObject.tag == "Badboie") {
					c.gameObject.SendMessage("ApplyDamage", 5.0);
				}
			}
			Destroy(gameObject);
		}
	}
}
