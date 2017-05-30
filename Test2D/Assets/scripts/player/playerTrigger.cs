using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTrigger : MonoBehaviour {

	// Damage
	public int dmg = 10;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.isTrigger == false && col.CompareTag ("Enemy")) {
			col.SendMessageUpwards ("Damage", dmg);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
