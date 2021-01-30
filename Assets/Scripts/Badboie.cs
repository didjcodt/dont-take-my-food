using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badboie: MonoBehaviour {
	// Set at spawn time
	public LineRenderer path = null;
	public float speed = 0f;

	// Set in unity
	public SpriteRenderer spriteRenderer = null;
	public Sprite releasedHammer = null;
	public Sprite pressedHammer = null;
	public float pressSpeed = 0f;

	public bool hammerPressed {get; private set; }

	// Internals
	// Line following point
	private int currentPoint = 0;
	// Hammer animation
	private float timeToNextHammerChange = 0f;

	void Start() {
		transform.position = path.GetPosition(0);
	}

	void Update() {
		// Update sprite if it's time
		timeToNextHammerChange -= Time.deltaTime;
		if(timeToNextHammerChange < 0f) {
			timeToNextHammerChange = pressSpeed;
			hammerPressed = !hammerPressed;
			if(hammerPressed)
				spriteRenderer.sprite = pressedHammer;
			else
				spriteRenderer.sprite = releasedHammer;
		}

		// Move forward
		transform.position = Vector3.MoveTowards(
				transform.position,
				path.GetPosition(currentPoint),
				speed*Time.deltaTime);

		// If estimate of next iteration makes us move too far, pass to the next.
		// In case it is the last point, destroy ourself
		if ((transform.position-path.GetPosition(currentPoint)).sqrMagnitude < (speed*Time.deltaTime) * (speed*Time.deltaTime) ) {
			currentPoint++;
			if(currentPoint == path.positionCount)
				Destroy(this.gameObject);
		}
	}

}
