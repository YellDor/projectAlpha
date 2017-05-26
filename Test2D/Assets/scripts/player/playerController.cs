using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	// movement variables
	public float max_speed;
	public float run;
	public int attack_damage;

	Rigidbody2D myRB;
	Animator animator;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>();
		attack_damage = 10;
	}
		


	// Update is called once per frame
	void FixedUpdate () {
		PlayerMovement ();
		playerAttack ();
	}

	void playerAttack () {
		if (Input.GetKey (KeyCode.Mouse0)) {
			
		}

	}

	void OnColliderCollisionHit (ControllerColliderHit hit) {
		if (hit.gameObject.name == "player") {
			
		}
		
	}

		
	void PlayerMovement () {
		float move = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis("Vertical");
		if (Input.GetKey(KeyCode.LeftShift)) {
			myRB.velocity = new Vector2 (move * (run), moveV * (run));
		} else {
			myRB.velocity = new Vector2 (move * max_speed, moveV * max_speed);
		}
	}
}
