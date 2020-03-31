﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;

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

 

    //==============================================================================================================================

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
            float x1 = touchPos.x;
            float x2 = deltaSwipe.x;
            float y1 = touchPos.y;
            float y2 = touchPos.y;

            //Debug.Log(deltaSwipe);


            if (Mathf.Abs(deltaSwipe.y) > swipeResistanceY )
			{
                //Swipe on the y axis
                Direction = (deltaSwipe.y < 0) ? SwipeDirection.Up : SwipeDirection.Down;

                if (Direction.Equals(SwipeDirection.Up) && deltaSwipe.x > 100)
                {
                    Direction = SwipeDirection.UpLeft;
                    Debug.Log(Direction);
                }
                else if(Direction.Equals(SwipeDirection.Up) && deltaSwipe.x < -100)
                {
                    Direction = SwipeDirection.UpRight;
                    Debug.Log(Direction);
                }
                if (Direction.Equals(SwipeDirection.Down) && deltaSwipe.x > 100)
                {
                    Direction = SwipeDirection.DownLeft;
                    Debug.Log(Direction);
                }
                else if (Direction.Equals(SwipeDirection.Down) && deltaSwipe.x < -100)
                {
                    Direction = SwipeDirection.DownRight;
                    Debug.Log(Direction);
                }
                else
                {
                    Debug.Log("Else    " + Direction);
                }
            }
            else if(Mathf.Abs(deltaSwipe.x) > swipeResistanceX)
            {
                Debug.Log("IN ELSE IF");
                Direction = (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;
                Debug.Log(Direction);
            }
        }//Mouse ButtUP
	}//Update

    //==============================================================================================================================


}


//==============================================================================================================================
//==============================================================================================================================
//==============================================================================================================================

public enum SwipeDirection
{
	None = 0,
	Left = 1,
	Right = 2,
	Up = 4,
	Down = 8,

	DownLeft= 9,
	UpLeft = 5,
	DownRight = 10,
	UpRight = 6
}
