using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SwipeDrawer : MonoBehaviour {

	private LineRenderer lineRenderer;

	private float zOffset = 10;

	private void Awake()
	{
		lineRenderer = GetComponent<LineRenderer>();
		SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
	}

	private void SwipeDetector_OnSwipe(SwipeData data)
	{
		Vector3[] pos = new Vector3[2];

		//change to world point to stay around cordinates (0,0)
		pos[0] = Camera.main.ScreenToWorldPoint(new Vector3(data.StartPosition.x, data.StartPosition.y, zOffset)); 
		pos[1] = Camera.main.ScreenToWorldPoint(new Vector3(data.EndPosition.x, data.EndPosition.y, zOffset));
		lineRenderer.positionCount = 2;
		lineRenderer.SetPositions(pos);
	}
}
