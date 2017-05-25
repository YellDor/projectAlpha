using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour {

	private GameObject player;
	private Vector3 startPos, newPos;
	private int speed;
	private bool moving;
	private int count;



	// Use this for initialization
	void Start () {
		startPos = transform.position;
		newPos = transform.position;
		speed = 1;
		moving = false;
		count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		moveCharacter ();
	}

	void moveCharacter () {
		if (count == 0) {
			moving = false;
		}
		if (!moving) {
			newPos = new Vector3 (pickX (), pickY (), transform.position.z);
			moving = true;
		}
		transform.position = Vector3.Lerp (transform.position, newPos, speed * (Time.deltaTime / 16));
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
}
