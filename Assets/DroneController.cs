using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {
	public Transform target;
	
	private List<Transform> props;
	private Rigidbody rb;

	public float Pgain = 0.001f;
	public float Dgain = 0.001f;

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
		Material mat = props[prop].GetComponent<MeshRenderer>().material;
		mat.color = new Color(255*(value - 0.5f), 0, 0);
		rb.AddForceAtPosition(transform.up * 5 * Mathf.Clamp(value, 0f, 1f), props[prop].position);
	}

	// Cap this between -180 and 180, instead of 0 to 360
	float center(float val) {
		if(val > 180) {
			return val - 360;
		}
		else {
			return val;
		}
	}
	
	void FixedUpdate () {
		float[] forces = new float[4];
		
		ApplyHeightControl(forces);
		ApplyAttitudePControl(forces);
		ApplyAttitudeDControl(forces);

		for(int i = 0; i < 4; i++) {
			ApplyPropForce(i, forces[i]);
		}
	}

	void ApplyAttitudePControl(float[] forces) {
		float x = center(transform.eulerAngles.x);
		float z = center(transform.eulerAngles.z);
		forces[0] += Pgain * ( x + z);
		forces[1] += Pgain * (-x - z);
		forces[2] += Pgain * ( x - z);
		forces[3] += Pgain * (-x + z);
	}

	void ApplyAttitudeDControl(float[] forces) {
		float x = center(rb.angularVelocity.x);
		float z = center(rb.angularVelocity.z);
		forces[0] += Dgain * ( x + z);
		forces[1] += Dgain * (-x - z);
		forces[2] += Dgain * ( x - z);
		forces[3] += Dgain * (-x + z);
	}

	Vector2 To2D(Vector3 v) {
		return new Vector2(v.x, v.z);
	}

	void ApplyHeightControl(float[] forces) {
		float basePower = 9.81f / 4 / 5;
		float Perror = target.position.y - transform.position.y;
		float Derror = -rb.velocity.y;

		Perror = Mathf.Clamp(Perror, -1f, 1f);
		Derror = Mathf.Clamp(Derror, -1f, 1f);

		for(int i = 0; i < forces.Length; i++) {
			forces[i] += basePower + (Perror * Pgain) + (Derror * Dgain);
		}
	}
}

