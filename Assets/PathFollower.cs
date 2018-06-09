using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {
	public float pathTotalTime = 5;
	public Transform targetIndicator;
	
	private BezierCurve curve;

	void Start () {
		curve = GetComponent<BezierCurve>();
	}
	
	void FixedUpdate () {
		float t = (Time.timeSinceLevelLoad / pathTotalTime) % 1f;
		Vector3 target = curve.GetPointAt(t);
		targetIndicator.position = target;
	}
}
