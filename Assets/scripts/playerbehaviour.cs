using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbehaviour : MonoBehaviour {
	private float moveSpeed = 50f;
	private float moveMaxSpeed = 53f;
	private Vector3 playerMovement;
	private Rigidbody playercube;

	// this is called when the game is initialized
	void Start (){
		playercube = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider allTriggers){
		Destroy (allTriggers.gameObject);
		print ("Game over!");
	}

	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		playerMovement = new Vector3 (moveHorizontal,0.0f,moveVertical);

		// the condition below for the playercube speed makes the pickup faster 
		// with the speed (snap and catches up with speed)
		if (playercube.velocity.magnitude < moveMaxSpeed) {
			playercube.AddForce (playerMovement * moveSpeed);
		}
	}
}
