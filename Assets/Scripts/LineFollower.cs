using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFollower : MonoBehaviour {
	// Set at spawn time
	public LineRenderer path = null;
	public float speed = 0f;

	// Internals
	private int currentPoint = 0;

	void Start() {
		transform.position = path.GetPosition(0);
	}

	void Update() {
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
