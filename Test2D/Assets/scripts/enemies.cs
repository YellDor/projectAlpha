using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour {

	private GameObject player;
	private Vector3 startPos, newPos;
	private int speed;
	private bool moving, spotted;
	private int count;
	private Rigidbody2D rigid;
	private int smoothing;



	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		resetStartPos ();
		newPos = transform.position;
		speed = 3;
		smoothing = 1;
		moving = false;
		spotted = false;
		count = 0;
		rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!spotted) {
			moveCharacter ();
		}
	}

	void moveCharacter () {
		if (count == 0) {
			moving = false;
		}
		if (!moving) {
			newPos = new Vector3 (pickX (), pickY (), transform.position.z);
			moving = true;
		}
		transform.position = Vector3.Lerp (transform.position, newPos, smoothing * (Time.deltaTime / 16));
		count++;
		if (count == 700) {
			moving = false;
			count = 0;
		}
	}

	int pickX () {
		return Random.Range ((int) startPos.x - 20, (int) startPos.x + 20);
	}

	int pickY () {
		return Random.Range ((int) startPos.y - 20, (int) startPos.y + 20);
	}

	void moveEnemy () {
		if (spotted) {
			int moveX, moveY;
			if (transform.position.x < player.transform.position.x) {
				moveX = 1;
			} else {
				moveX = -1;
			}
			if (transform.position.y < player.transform.position.y) {
				moveY = 1;
			} else {
				moveY = -1;
			}
			rigid.velocity = new Vector2 (moveX * (speed), moveY * (speed));
		}
	}

	void stopEnemy () {
		// Stop the enmy moving
		rigid.velocity = new Vector2 (0, 0);

		transform.position = Vector3.Lerp (transform.position, startPos, smoothing * (Time.deltaTime / 16));
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.name == "player") {
			// Start shooting the palyer
			spotted = true;
			moveEnemy();
		}
	}

	void resetStartPos () {
		startPos = transform.position;
	}


	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.name == "player") {
			spotted = false;
			stopEnemy ();
			resetStartPos ();
		}
	}
}
