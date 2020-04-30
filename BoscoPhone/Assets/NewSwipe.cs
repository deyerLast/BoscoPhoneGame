using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSwipe : MonoBehaviour {

	private Vector3 position;
	private float width;
	private float height;
	static GameObject particle;

	private void Awake()
	{
		width = (float)Screen.width / 2.0f;
		height = (float)Screen.height / 2.0f;

		//Pos of cube
		position = new Vector3(0.0f, 0.0f, 0.0f);
	}

	private void OnGUI()
	{
		GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

		GUI.Label(new Rect(20,20,width,height * 0.35f),
		"x = " + position.x.ToString("f2") +
			", y = " + position.y.ToString("f2"));
	}

	private void Update()
	{
		//Handle the screen touch now
		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			//Move the cube if screen has the finger moving
			if(touch.phase == TouchPhase.Moved)
			{
				Vector2 pos = touch.position;
				pos.x = (pos.x - width) / width;
				pos.y = (pos.y - height) / height;
				position = new Vector3(pos.x, pos.y, 0.0f);

				//Position cube
				transform.position = position;
			}
			if(Input.touchCount == 2)
			{
				touch = Input.GetTouch(1);

				if(touch.phase == TouchPhase.Began)
				{
					//Halve size of cube
					transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
				}
				if(touch.phase == TouchPhase.Ended)
				{
					//Restore regular size of the cube
					transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
				}
			}
		}

		foreach(Touch touch in Input.touches)
		{
			if(touch.phase == TouchPhase.Began)
			{
				//Construct ray from the current touch coordinates
				Ray ray = Camera.main.ScreenPointToRay(touch.position);
				if (Physics.Raycast(ray))
				{
					//Create particale if hit
					Instantiate(particle, transform.position, transform.rotation);
				}
				
			}
		}
	}
}
