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
		// checks if they have spotted a player if not then move idley
		if (!spotted) {
			moveIdle ();
		}
	}
		
	void moveIdle () {
		if (count == 0) {
			moving = false;
		}

		if (!moving) {
			// sets where the enemy will need to move to
			newPos = new Vector3 (pickX (), pickY (), transform.position.z);
			// tells the enemy it should be moving now
			moving = true;
		}
		// moves the enemy towards the random position set
		transform.position = Vector3.Lerp (transform.position, newPos, smoothing * (Time.deltaTime / 16));
		// adds one to count
		count++;
		// if count reaches 700 then set it back to 0 and set moving to false
		if (count == 700) {
			moving = false;
			count = 0;
		}
	}

	// picks a random x position for the enemy to move to
	int pickX () {
		// if you need to change the distance it travels then cahnge the 20 int
		return Random.Range ((int) startPos.x - 20, (int) startPos.x + 20);
	}

	//  picks a random y position for the enemy to move to
	int pickY () {
		// if you need to change the distance it travels then cahnge the 20 int
		return Random.Range ((int) startPos.y - 20, (int) startPos.y + 20);
	}

	// moves the enemy towards the player if they have been spotted
	void moveEnemy () {
		// checks if a player has been spotted
		if (spotted) {
			int moveX, moveY;
			// finds the position of the player
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

			// Moves the enemy towards the palyer at speed
			rigid.velocity = new Vector2 (moveX * (speed), moveY * (speed));
		}
	}

	void stopEnemy () {
		// Stop the enmy moving when it is out of range
		rigid.velocity = new Vector2 (0, 0);
		// Go back to the starting position
		transform.position = Vector3.Lerp (transform.position, startPos, smoothing * (Time.deltaTime / 16));
	}

	// checks if the enemy is inside the collision area
	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.name == "player") {
			// Start shooting the palyer
			spotted = true;
			moveEnemy();
		}
	}

	// resets the position of the enemy
	void resetStartPos () {
		startPos = transform.position;
	}

	// finds out if the player has exited the enemy range
	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.name == "player") {
			// Says that it is no longer spotted
			spotted = false;
			// stops the enemy from moving
			stopEnemy ();
			// rests the home position of the enemy to move from there
			resetStartPos ();
		}
	}
}
