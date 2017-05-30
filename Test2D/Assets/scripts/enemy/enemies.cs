using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies : MonoBehaviour {

	private static GameObject player;
	public static Vector3 startPos, newPos;
	public static int speed;
	private bool moving;
	private static int count;
	private static Rigidbody2D rigid;
	private static Transform trans;
	public static int smoothing;
	private static int health;



	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		newPos = transform.position;
		speed = 3;
		smoothing = 1;
		moving = false;
		count = 0;
		health = 100;
		rigid = GetComponent<Rigidbody2D>();
		trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		// checks if they have spotted a player if not then move idley
		if (!enemyPathFinding.spotted) {
			moveIdle ();
		}

		if (health <= 0 ) {
			kill();
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

	public static void moveAttack (Vector2 vec) {
		rigid.velocity = vec;
	}

	public static void stopEnemy () {
		// Stop the enmy moving when it is out of range
		moveAttack(new Vector2 (0, 0));
		// Go back to the starting position
		trans.position = Vector3.Lerp (trans.position, startPos, smoothing * (Time.deltaTime / 16));
	}

	public void kill () {
		Destroy(gameObject);
	}


	public void Damage (int damage) {
		health -= damage;
		print (health + " this is the health");

	}
}
