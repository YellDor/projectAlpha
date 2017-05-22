using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endpoint : MonoBehaviour {

	public GameObject player;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onCollisionEnter (Collision col) {
		if (col.gameObject.tag == "Player") {
			Destroy (col.gameObject);
		}


	}


}
