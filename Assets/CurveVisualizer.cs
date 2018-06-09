using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveVisualizer : MonoBehaviour {

	public int sections = 10;

	private BezierCurve curve;
	private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		curve = GetComponent<BezierCurve>();
		lineRenderer = GetComponent<LineRenderer>();
		float delta = 1f/sections;
		Vector3[] points = new Vector3[sections + 1];

		float t = 0;
		for(int i = 0; i < points.Length; i++) {
			points[i] = curve.GetPointAt(t);
			t += delta;
		}
		lineRenderer.positionCount = sections + 1;
		lineRenderer.SetPositions(points);
	}
}
