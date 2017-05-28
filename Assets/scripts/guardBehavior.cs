using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardBehavior : MonoBehaviour {
	private Vector3 guardStartPosition = new Vector3(-1.25f,-0.25f,2.5f);
	private Vector3 guardEndPosition = new Vector3(-1.25f,-0.25f,-2.5f);
	private float patrolSpeed = 0.5f;

	// Update is called once per frame
	void Update () {
		// make a patrolling movement with the guard
		transform.position = 
			Vector3.Lerp ( guardStartPosition, guardEndPosition,
						   Mathf.PingPong(Time.time*patrolSpeed, 1.0f ));

	}
}
