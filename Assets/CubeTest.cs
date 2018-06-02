using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour {
	private List<Transform> props;
	private Rigidbody rb;

	public float basePropPower = 0.50f;
	public float Pgain = 0.001f;
	public float Dgain = 0.001f;

	// Use this for initialization
	void Start () {
		props = new List<Transform>();
		rb = GetComponent<Rigidbody>();
		foreach(Transform t in GetComponentsInChildren<Transform>()) {
			if(t != transform) {
				props.Add(t);
			}
		}
	}

	void ApplyPropForce(int prop, float value) {
		rb.AddForceAtPosition(transform.up * 5 * Mathf.Clamp(value, 0f, 1f), props[prop].position);
	}
	
	void FixedUpdate () {
		float x = transform.eulerAngles.x;
		float z = transform.eulerAngles.z;
		
		float vx = rb.angularVelocity.x;
		float vz = rb.angularVelocity.z;
		
		ApplyPropForce(0, basePropPower - (Pgain * x + Dgain * vx) + (Pgain * z + Dgain * vz));
		ApplyPropForce(1, basePropPower + (Pgain * x + Dgain * vx) - (Pgain * z + Dgain * vz));
		ApplyPropForce(2, basePropPower - (Pgain * x + Dgain * vx) + (Pgain * z + Dgain * vz));
		ApplyPropForce(3, basePropPower + (Pgain * x + Dgain * vx) - (Pgain * z + Dgain * vz));
		
	}
}
