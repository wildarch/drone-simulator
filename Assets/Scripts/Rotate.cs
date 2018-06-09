using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.angularVelocity = new Vector3(0, 500f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
