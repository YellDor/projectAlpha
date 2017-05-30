using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPathFinding : MonoBehaviour {

	public static bool spotted;
	private GameObject player;
	private GameObject enemy;
	private int speed;
	private Rigidbody2D rigid;



	// Use this for initialization
	void Start () {
		speed = 3;
		resetStartPos ();
		spotted = false;
		rigid = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// moves the enemy towards the player if they have been spotted
	void moveEnemy () {
		// checks if a player has been spotted
		if (spotted) {
			int moveX, moveY;
			// finds the position of the player
			if (transform.position.x < player.transform.position.x + 1) {
				moveX = 1;
			} else {
				moveX = -1;
			}
			if (transform.position.y < player.transform.position.y + 1) {
				moveY = 1;
			} else {
				moveY = -1;
			}
			// Moves the enemy towards the palyer at speed
			enemies.moveAttack(new Vector2 (moveX * (speed), moveY * (speed)));
			moveAttack (new Vector2 (moveX * (speed), moveY * (speed)));
		}
	}



	// checks if the enemy is inside the collision area
	void OnTriggerStay2D (Collider2D col) {
		if (col.gameObject.name == "player") {
			// Found the player and will move to it
			spotted = true;
			moveEnemy();
		}
	}

	// resets the position of the enemy
	void resetStartPos () {
		enemies.startPos = transform.position;
	}

	// finds out if the player has exited the enemy range
	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.name == "player") {
			// Says that it is no longer spotted
			spotted = false;
			// stops the enemy from moving
			enemies.stopEnemy ();
			stopEnemy ();
			// rests the home position of the enemy to move from there
			resetStartPos ();
		}
	}


	public void moveAttack (Vector2 vec) {
		rigid.velocity = vec;
	}

	public void stopEnemy () {
		// Stop the enmy moving when it is out of range
		moveAttack(new Vector2 (0, 0));
		// Go back to the starting position
		transform.position = Vector3.Lerp (transform.position, enemies.startPos, enemies.smoothing * (Time.deltaTime / 16));
	}
}
