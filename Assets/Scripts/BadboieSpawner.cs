using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadboieSpawner: MonoBehaviour {
	// Set in Unity
	public GameObject badboiePrefab = null;
	public float spawnFrequency = 0f;
	public float ennemiesSpeed = 0f;
	public LineRenderer badboiesPath = null;
	public GameState gameState = null;
	public int numberOfBadboies = 0;

	// Internals
	private float timeUntilNextSpawn = 0f;

	void Update() {
		if(gameState.gameFinished)
			return;

		timeUntilNextSpawn -= Time.deltaTime;

		if(timeUntilNextSpawn < 0f) {
			timeUntilNextSpawn = spawnFrequency;
			// Spawn a new badboie and set its parameters
			if(numberOfBadboies > 0) {
				var badboie = Instantiate(badboiePrefab, badboiesPath.GetPosition(0), Quaternion.identity);
				badboie.GetComponent<Badboie>().path = badboiesPath;
				badboie.GetComponent<Badboie>().speed = ennemiesSpeed;
			} else {
				// End of the game, we win!
				gameState.gameFinished = true;
				return;
			}
		}
	}
}
