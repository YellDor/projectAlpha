using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour {


	public Transform target;
	public Transform camera;


	// Use this for initialization
	void Start () {
		resetPlayer ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void resetPlayer () {
		camera.position = new Vector3 (transform.position.x, camera.position.y, camera.position.z);
		target.position = transform.position;
	}
}
