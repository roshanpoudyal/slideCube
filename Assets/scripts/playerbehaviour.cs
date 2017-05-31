using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerbehaviour : MonoBehaviour {
	private float moveSpeed = 50f;
	private float moveMaxSpeed = 52f;
	private Vector3 playerMovement;
	private Rigidbody playercube;
	private Vector3 playerStartPosition;

	public GameObject explosionobject;
	public Renderer playerrenderer;

	// this is called when the game is initialized
	void Start (){
		playercube = GetComponent<Rigidbody> ();

		playerStartPosition = playercube.transform.position;
	}

	// do this on entering destination trigger
	void OnTriggerEnter(Collider allTriggers){
		if (allTriggers.gameObject.name == "trigger") {
			StartCoroutine (pauseGame ("triggercalls"));
		}

		if (allTriggers.gameObject.name == "guard") {
			StartCoroutine (pauseGame ("guardcalls"));
		}
	}
		
	// do this on falling down to abyss, i.e out of ground
	// since our player is never jumping and is always in 
	// collision with ground, when the player is out of the ground 
	// is the only time when it exits collision, and thus
	void OnCollisionExit(Collision exitcollisionfrom){
		if (exitcollisionfrom.collider.name == "ground") {
			StartCoroutine (pauseGame ("groundcalls"));
		}	
	}

	// this Coroutine is called by from ontriggerenter
	// to make sure the player is repositioned when 
	IEnumerator pauseGame(string callfrom) {
		//make the playercube stop
		moveSpeed = 0f;

		switch(callfrom){
		case "triggercalls":
			print ("congratulations! game over");
			break;
		
		case "guardcalls":
			// off the display of player
			playerrenderer.enabled = false;

			// instantiate explosion prefab at players current position
			Instantiate (explosionobject, transform.position, Quaternion.identity);
			print ("enemey killed the player");
			break;

		case "groundcalls":
			print ("player is falling");
			break;

		default :
			break;
		}

		//wait for some time
		yield return new WaitForSeconds(4);

		// reset the playercube to starting position
		playercube.transform.position = playerStartPosition;

		//display the player again
		if(!playerrenderer.isVisible) {playerrenderer.enabled = true;}

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
