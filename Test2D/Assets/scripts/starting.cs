using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starting : MonoBehaviour {


	public Transform target;
	public Vector3 self;


	// Use this for initialization
	void Start () {
		target.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
