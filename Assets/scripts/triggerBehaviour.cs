using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerBehaviour : MonoBehaviour {
	public Material triggermaterial1;
	public Material triggermaterial2;
	private float duration = 1f;
	private Renderer renderobject;

	// this is called when the game is initialized
	void Start (){
		renderobject = GetComponent<Renderer> ();
		renderobject.material = triggermaterial1;
	}

	// Update is called once per frame
	void Update () {
		float lerp = Mathf.PingPong (Time.time, duration);
		renderobject.material.Lerp (triggermaterial1, triggermaterial2, lerp);
	}
}
