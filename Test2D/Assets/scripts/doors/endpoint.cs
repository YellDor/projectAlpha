using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endpoint : MonoBehaviour {

	public GameObject player;
	private Rigidbody2D rigid;

	void Start () {
		rigid = GetComponent<Rigidbody2D>();
		rigid.freezeRotation = true;

	}

	void update () {
		
	}


	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.name == "player" && Input.GetKey(KeyCode.G)) {
			player.transform.position = new Vector3 (0, 0, 10);
			SceneManager.LoadScene ("level2");
		}
	}


}
