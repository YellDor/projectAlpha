using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	// movement variables
	public float maxSpeed;
	public float run;

	Rigidbody2D myRB;
	Animator animator;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		System.Console.WriteLine ("yay");
		float move = Input.GetAxis ("Horizontal");
		float moveV = Input.GetAxis("Vertical");
		if (Input.GetKey(KeyCode.LeftShift)) {
			myRB.velocity = new Vector2 (move * (run), moveV * (run));
		} else {
			myRB.velocity = new Vector2 (move * maxSpeed, moveV * maxSpeed);
		}
	}
}
