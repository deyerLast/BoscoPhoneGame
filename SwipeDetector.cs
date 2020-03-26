using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SwipeDetector : MonoBehaviour {

	private Vector2 fingerDownPos;
	private Vector2 fingerUpPos;

	[SerializeField]
	private bool detectSwipeOnlyAfterRelease = false;

	[SerializeField]
	private float minDistanceForSwipe = 20f;

	public static event Action<SwipeData> OnSwipe = delegate { }; //reused accross project, so it should be static. 

	// Use this for initialization
	/*void Start() {

	}*/

	// Update is called once per frame
	private void Update() {
		foreach (Touch touch in Input.touches)
		{
			if (touch.phase == TouchPhase.Began)
			{
				fingerUpPos = touch.position;
				fingerDownPos = touch.position;
			}

			if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
			{
				fingerDownPos = touch.position;
				DetectSwipe();
			}

			if (touch.phase == TouchPhase.Ended)
			{
				fingerDownPos = touch.position;
				DetectSwipe();
			}
		}
	}

	private void DetectSwipe()
	{
		if (SwipeDistanceCheckMet())//disctance more than 20
		{
			if (IsVerticalSwipe())
			{
				var direction = fingerDownPos.y - fingerUpPos.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
				SendSwipe(direction);
			}
			else
			{
				var direction = fingerDownPos.x - fingerUpPos.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
				SendSwipe(direction);
			}
			fingerUpPos = fingerDownPos;
		}
	}



	public struct SwipeData
	{
		public Vector2 StartPosition;
		public Vector2 EndPosition;
		public SwipeDirection Direction;
	}

	private bool IsVerticalSwipe()
	{
		return VerticalMovementDistance() > HorizontalMovementDistance();
	}
	private bool SwipeDistanceCheckMet()
	{
		return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
	}
	private float VerticalMovementDistance()
	{
		return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
	}
	private float HorizontalMovementDistance()
	{
		return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
	}

	private void SendSwipe(SwipeDirection direction)
	{
		SwipeData swipeData = new SwipeData()
		{
			Direction = direction,
			StartPosition = fingerDownPos,
			EndPosition = fingerUpPos
		};
		OnSwipe(swipeData);
	}

}//end script


public struct SwipeData
{
	public Vector2 StartPosition;
	public Vector2 EndPosition;
	public SwipeDirection Direction;
}

public enum SwipeDirection
{
	Up,
	Down,
	Left,
	Right
}
