using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endpoint : MonoBehaviour {

	public BoxCollider2D target;
	public GameObject thing;
	private Transform target2 = null;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void onTriggerEnter (BoxCollider2D other) {
		if (other.CompareTag ("Player")) {
			other.transform.position = new Vector3 (0, 0, 0);
		}

	}
}
