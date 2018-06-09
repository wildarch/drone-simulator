using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoisyStateEstimator : MonoBehaviour {
	public Vector3 positionNoise;
	
	public Transform realState;

	// Use this for initialization
	void Start () {
		if(realState == null) {
			realState = GetComponent<Transform>();
		}
	}
	
	public Vector3 getPosition() {
		Vector3 noise = new Vector3(
			positionNoise.x * (Random.value - 0.5f),
			positionNoise.y * (Random.value - 0.5f),
			positionNoise.z * (Random.value - 0.5f)
		);
		return realState.position + noise;
	}


}
