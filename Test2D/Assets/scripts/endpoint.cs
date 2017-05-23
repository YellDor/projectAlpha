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
		print ("Hello worl");
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.name == "player") {
			col.transform.position = new Vector3 (0, 0, 0);
			print ("Hello worl");

		}
		player.transform.position = new Vector3 (0, 0, 0);
		Debug.Log ("this is running");
	}


}
