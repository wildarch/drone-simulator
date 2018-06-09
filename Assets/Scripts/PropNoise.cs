using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropNoise : MonoBehaviour {
	public float noiseLevel = 1.0f;

	private Rigidbody parentRb;

	// Use this for initialization
	void Start () {
		parentRb = (Rigidbody) GetComponentInParent(typeof(Rigidbody));
	}
	
	void FixedUpdate () {
		Vector3 noise = new Vector3(
			noiseLevel*(Random.value-0.5f), 
			noiseLevel*(Random.value-0.5f), 
			noiseLevel*(Random.value-0.5f)
		);
		parentRb.AddForceAtPosition(noise, transform.parent.up);
	}
}
