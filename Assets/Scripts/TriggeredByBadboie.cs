using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredByBadboie : MonoBehaviour
{
	// Set in unity
	public Sprite BowlFull = null;
	public Sprite BowlEmpty = null;

	public bool isTriggered = false;

	void Update() {
		if(isTriggered)
			gameObject.GetComponent<SpriteRenderer>().sprite = BowlEmpty;
		else
			gameObject.GetComponent<SpriteRenderer>().sprite = BowlFull;
	}

	private void OnTriggerEnter2D(Collider2D collider) {
		if(collider.gameObject.tag == "Badboie")
			isTriggered = true;
	}
}
