using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2DPlatformer : MonoBehaviour {


	public Transform target; // What the camera is following
	public float smoothing; // the dampaning effect the cmaera has when following

	private Vector3 offset;

	private float lowY;


	// Use this for initialization
	void Start () {
		// gets the difference between the target and camera
		offset = transform.position - target.position;
		// Sets where the cameras y position so it doesnt change
		lowY = transform.position.y;
	

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Where the camera want to be
		Vector3 targetCamPos = target.position + offset;

		// slowly move it to that position
		transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);

		// Stops the movemnt in the up down motion
		transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
	}
}
