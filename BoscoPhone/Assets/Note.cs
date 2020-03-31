using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {

    //ArrayList noteList = new ArrayList();
	Rigidbody2D rb;
	public float speed;
    //public int numberOfNotes;
    //public SwipeDirection swipe;


    //==============================================================================================================================
    //==============================================================================================================================

    private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();//This was for collisions
	}

    //============================================================================================================================

    // Use this for initialization
    void Start () {
		rb.velocity = new Vector2(-speed, 0);//The Balls will fall and then sit in SSlider?
		//Put a count down clock in to start the game?
	}

    //==============================================================================================================================

    // Update is called once per frame
    void Update () {
        //if swipe matche{
        //if collision with handle, then speed 0.
            //Else if collision = other note, speed = 0.
	}



    //==============================================================================================================================
    //==============================================================================================================================


}
