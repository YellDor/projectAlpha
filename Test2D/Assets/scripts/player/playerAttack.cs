using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour {

	private bool attacking = false;
	private float attackTimer = 0;
	private float attackCoolDown = 0.6f;

	public Collider2D attackTrigger;

	private Animator anim;


	// Use this for initialization
	void Start () {
		// Disabaling the box collider in the attackTrigger
		attackTrigger.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.C) && !attacking) {
			attacking = true;
			attackTimer = attackCoolDown;
			attackTrigger.enabled = true;
		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				attackTrigger.enabled = false;
			}
		}
	}
}
