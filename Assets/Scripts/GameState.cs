using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
	// Set in unity
	public Collider2D objective = null;
	public GameObject winScreen = null;
	public GameObject looseScreen = null;

	// Internals
	public bool gameFinished { get; set; }
	public bool noMoreBadboies { get; set; }
	public bool gameLost { get; private set; }

	void Start() {
	}

	void Update() {
		if(noMoreBadboies)
			if(GameObject.FindGameObjectsWithTag("Badboie").Length == 0)
				gameFinished = true;

		if(objective.GetComponent<TriggeredByBadboie>().isTriggered) {
			gameFinished = true;
			gameLost = true;
		}

		if(gameFinished) {
			if(gameLost) looseScreen.SetActive(true);
			else winScreen.SetActive(true);
		}
	}
}
