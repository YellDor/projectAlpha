using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endpoint : MonoBehaviour {

	public GameObject player;
	private playerController playerCon;
	public GameObject startObj;
	public GameObject start;
	private Rigidbody2D rigid;

	void Start () {
		rigid.freezeRotation = true;

	}

	void update () {
		
	}


	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.name == "player") {
			

		}
	}


}
