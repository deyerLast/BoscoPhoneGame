using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressed : MonoBehaviour {

	
	private void OnMouseDown()
	{
		Destroy(gameObject);
	}
}
