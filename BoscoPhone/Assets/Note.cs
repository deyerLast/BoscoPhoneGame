
using System.Collections;
//using System.Diagnostics.Contracts;
using UnityEngine;

public class Note : MonoBehaviour {

    //ArrayList noteList = new ArrayList();
	Rigidbody2D rb;
	public float speed;
    public SwipeDirection swipeDirection;
    public Random rnd = new Random();
    GameObject noteStuff;
    public SwipeDirection NoteDirection { set;get;}

    
    SwipeManager swipe;
    

    //==============================================================================================================================
    //==============================================================================================================================

    private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();//This was for collisions
	}



    //============================================================================================================================

    // Use this for initialization///CONSTRUCTOR
    void Start () {
        speed = 100f;
		rb.velocity = new Vector2(-speed, 0);//The Balls will fall and then sit in SSlider?
		GameObject note;
        int num = 1;
        
        note = new GameObject("Note" + num);
        var unused = note.AddComponent<SwipeManager>().Direction;
        
        createRndDirection();
        swipeDirection = NoteDirection;

        note.AddComponent<Note>();
        
        //have to include SwipeDirection here. 
        
        
    }


    //==============================================================================================================================

    // Update is called once per frame
    void Update () {
        //Should be in a private void method 
        /*if (swipe.Direction.Equals(NoteDirection))
        {
            Destroy(this) )//If noteStuff collides with box collider2d, 
        {
            //speed =0;
            speed = 0;
        }
        */
        if( rb.collisionDetectionMode.Equals( GameObject.FindGameObjectWithTag( "NoteStopper" ) )  || rb.collisionDetectionMode.Equals(GameObject.FindGameObjectWithTag("Note")))
        {
            //Vector2 tempVector =  rb.GetPoint();
            //rb.position.Set();
        }

     
        
	}

    



    //==============================================================================================================================
    //==============================================================================================================================

    public SwipeDirection createRndDirection()
    {
        int num = Random.Range(1, 8);//Create number between 1-8
        Debug.Log(num);
        switch (num)
        {
            case 1:
                NoteDirection = SwipeDirection.Down;
                break;
            case 2:
                NoteDirection = SwipeDirection.DownRight;
                break;
            case 3:
                NoteDirection = SwipeDirection.Right;
                break;
            case 4:
                NoteDirection = SwipeDirection.UpRight;
                break;
            case 5:
                NoteDirection = SwipeDirection.Up;
                break;
            case 6:
                NoteDirection = SwipeDirection.UpLeft;
                break;
            case 7:
                NoteDirection = SwipeDirection.Left;
                break;
            case 8:
                NoteDirection = SwipeDirection.DownLeft;
                break;
            default:
                Debug.Log("Err Class NoteGen_RndNumb_Switch");
                break;
        }
        return NoteDirection;
    }


}
