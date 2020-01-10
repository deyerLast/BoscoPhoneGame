using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {


	//Ball park instead of BPM way.
	Rigidbody2D rb;
	public float speed;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	// Use this for initialization
	void Start () {
		rb.velocity = new Vector2(0, -speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
