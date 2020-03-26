using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour {

	private static SwipeManager instance;
	public static SwipeManager Instance { get { return instance; } }

	public SwipeDirection Direction { set; get; } //this is a property

	private Vector3 touchPos;
	private float swipeResistanceX = 20f;
	private float swipeResistanceY = 20f;

	private void Start()
	{
		instance = this;
	}

	void Update()
	{

		Direction = SwipeDirection.None;//Each frame direction is set to nothing

		if (Input.GetMouseButtonDown(0))
		{
			touchPos = Input.mousePosition;
		}

		if (Input.GetMouseButtonUp(0))
		{
			Vector2 deltaSwipe = touchPos - Input.mousePosition;
			if (Mathf.Abs(deltaSwipe.x) > swipeResistanceX)
			{
				//Swipe on the X axis
				Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;
			}

			if (Mathf.Abs(deltaSwipe.y) > swipeResistanceY)
			{
				//Swipe on the y axis
				Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Up : SwipeDirection.Down;

			}
		}
	}

	public bool IsSwiping(SwipeDirection dir)
	{
		if(dir == Direction)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}

public enum SwipeDirection
{
	None = 0,
	Left = 1,
	Right = 2,
	Up = 4,
	Down = 8,

	LeftDown = 9,
	LeftUp = 5,
	RightDown = 10,
	RightUp = 6
}