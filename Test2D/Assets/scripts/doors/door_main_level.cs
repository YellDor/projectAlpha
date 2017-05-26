using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door_main_level : MonoBehaviour {

	private GameObject player;
	private Rigidbody2D rigid;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		rigid = GetComponent<Rigidbody2D>();
		rigid.freezeRotation = true;

	}

	void update () {

	}


	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.name == "player" && Input.GetKey(KeyCode.G)) {
			player.transform.position = new Vector3 (0, 0, 10);
			SceneManager.LoadScene ("test");
		}
	}


}
