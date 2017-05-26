using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	// movement variables
	public float max_speed;
	public float run;
	// How much you attack
	public int attack_damage;

	Rigidbody2D myRB;
	Animator animator;

	// Use this for initialization
	void Start () {
		// sets the rigiBody component to a variable
		myRB = GetComponent<Rigidbody2D>();
		// sets how much damage you do to enemies
		attack_damage = 10;
	}
		


	// Update is called once per frame
	void FixedUpdate () {
		// moves the player around the screen
		PlayerMovement ();
	}

		
	void PlayerMovement () {
		// getes what way the player should be going
		// Compatable for keyboard and controller
		float move = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis("Vertical");

		// If they are pressing shift then make them run
		if (Input.GetKey(KeyCode.LeftShift)) {
			myRB.velocity = new Vector2 (move * (run), moveV * (run));
		} else {// else walk at normal speed
			myRB.velocity = new Vector2 (move * max_speed, moveV * max_speed);
		}
	}
}
