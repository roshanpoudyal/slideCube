using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionbehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 1f);
	}
}
