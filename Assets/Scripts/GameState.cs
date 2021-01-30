using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
	// Set in unity
	public Collider2D objective = null;

	// Internals
	public bool gameFinished { get; set; }
	public bool gameLost { get; private set; }

	void Start() {
	}

	void Update() {
		if(gameFinished)
			return;

		if(objective.GetComponent<TriggeredByBadboie>().isTriggered) {
			gameFinished = true;
			gameLost = true;
		}
	}
}
