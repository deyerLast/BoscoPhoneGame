using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Activator : MonoBehaviour {


	public KeyCode key;
	//private SwipeDirection swipe;
	bool active = false;
	GameObject note;

	private Vector3 desiredPos;
	private Vector3 offset;

	public float smoothSpeed = 7.5f;
	public float distance = 5.0f;
	public float yOffset = 0.0f;
	



	/*//Touch stuff
	private Vector2 fingDownPos;
	private Vector2 fingUpPos;
	[SerializeField]
	private bool detectSwipeOnlyAfterRelease = false;
	[SerializeField]
	private float minDistanceForSwipe = 20f;
	public static event Action<SwipeData> OnSwipe = delegate { };
	//variable for swiping collection*/



	private void Awake() //when the program awakes
	{
		//swipe = GetComponent<SwipeDirection>();
		//Debug.Log("Swipe in Direction: " + swipe);
	}

	//======================================================================================================

	// Use this for initialization
	private void Start()
	{

	}

	//======================================================================================================

	// Update is called once per frame
	private void Update () {


		/*	if (Input.GetKeyDown(key) && active)
			{
				Destroy(note);
			}*/

		/*if ( SwipeManager.Instance.IsSwiping(SwipeDirection.Left))
		{
			Destroy(note);
		}*/
		
	}

	//======================================================================================================

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//active = true;
		if (collision.gameObject.tag == "Note")
		{
			note = collision.gameObject;
			active = true;
		}
	}

	//======================================================================================================

	private void OnTriggerExit2D(Collider2D other)
	{
		active = false;
	}

	//======================================================================================================

}