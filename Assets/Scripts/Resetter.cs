using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour {

	private Rigidbody rb;

	private Vector3 position;
	private Quaternion rotation;
	private Vector3 velocity;
	private Vector3 angularVelocity;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		position = rb.position;
		rotation = rb.rotation;
		velocity = rb.velocity;
		angularVelocity = rb.angularVelocity;
	}

	void ResetRigibody() {
		rb.position = position;
		rb.rotation = rotation;
		rb.velocity = velocity;
		rb.angularVelocity = angularVelocity;
	}
	
	void OnMouseDown() {
		ResetRigibody();
	}

	void Update() {
		if(Input.GetKey(KeyCode.R)) {
			ResetRigibody();
		}
	}
}
