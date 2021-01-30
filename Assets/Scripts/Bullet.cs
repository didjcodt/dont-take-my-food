using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.tag == "Badboie") {
			collider.gameObject.SendMessage("ApplyDamage", 5.0);
			Destroy(gameObject);
		}
	}
}
