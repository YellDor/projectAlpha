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
		rigid = GetComponent<Rigidbody2D>();
		rigid.freezeRotation = true;
	}

	void update () {
		
	}


	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.name == "player") {
			player.transform.position = new Vector3 (0, 0, 10);
		}
	}


}
