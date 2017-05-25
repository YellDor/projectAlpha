using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endpoint : MonoBehaviour {

	public GameObject player;
	private playerController playerCon;
	private start start;
	public GameObject startObj;
	private Rigidbody2D rigid;

	void Start () {
		rigid.freezeRotation = true;

	}

	void update () {
		
	}


	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.name == "player") {
			//start.resetPlayer ();
		}
	}


}
