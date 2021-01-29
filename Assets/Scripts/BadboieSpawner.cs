using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadboieSpawner: MonoBehaviour {
	// Set in Unity
	public GameObject badboiePrefab = null;
	public float spawnFrequency = 0f;
	public float ennemiesSpeed = 0f;
	public LineRenderer badboiesPath = null;

	// Internals
	private float timeUntilNextSpawn = 0f;

	void Start() {
	}

	void Update() {
		timeUntilNextSpawn -= Time.deltaTime;

		if(timeUntilNextSpawn < 0f) {
			timeUntilNextSpawn = spawnFrequency;
			// Spawn a new badboie and set its parameters
			var badboie = Instantiate(badboiePrefab, badboiesPath.GetPosition(0), Quaternion.identity);
			badboie.GetComponent<LineFollower>().path = badboiesPath;
			badboie.GetComponent<LineFollower>().speed = ennemiesSpeed;
		}
	}
}
