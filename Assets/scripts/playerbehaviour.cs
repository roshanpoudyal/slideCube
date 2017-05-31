using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerbehaviour : MonoBehaviour {
	private float moveSpeed = 50f;
	private float moveMaxSpeed = 53f;
	private Vector3 playerMovement;
	private Rigidbody playercube;
	private Vector3 playerStartPosition;

	// this is called when the game is initialized
	void Start (){
		playercube = GetComponent<Rigidbody> ();

		playerStartPosition = playercube.transform.position;
	}

	void OnTriggerEnter(Collider allTriggers){
		StartCoroutine(pauseGame());
	}

	// this Coroutine is called by from ontriggerenter
	// to make sure the player is repositioned when 
	IEnumerator pauseGame() {
		//make the playercube stop
		moveSpeed = 0f;

		//wait for some time
		yield return new WaitForSeconds(5);

		// reset the playercube to starting position
		playercube.transform.position = playerStartPosition;

		// make the player able to move on getting keyboard input
		// find a better way to make the player stop this is a workaround
		moveSpeed = 50f;
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
