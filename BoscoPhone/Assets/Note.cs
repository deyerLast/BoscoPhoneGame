
using System.Collections;
//using System.Diagnostics.Contracts;
using UnityEngine;

public class Note : MonoBehaviour {

    //ArrayList noteList = new ArrayList();
	Rigidbody2D rb;
	public float speed;
    public SwipeDirection swipeDirection;
    public Random rnd = new Random();
	static int maxNotes;
    GameObject noteStuff;
	//Sprite noteSprite;
    public SwipeDirection NoteDirection { set;get;}
	bool active = false;
	public static Vector3 noteScale = new Vector3(30.5f,30.5f,1.0f);

	SwipeManager swipe;



	public Sprite Down,Right,Left,Up,uRight,dRight,uLeft,dLeft;
    

    //==============================================================================================================================
    //==============================================================================================================================

    private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();//This was for collisions
		this.GetComponent<Renderer>().bounds.size.y.Equals(2f);

	}



	//============================================================================================================================

	// Use this for initialization///CONSTRUCTOR
	void Start() {
		speed = 100f;
		rb.velocity = new Vector2(-speed, 0);//The Balls will fall and then sit in SSlider?
		swipeDirection = CreateRndDirection();
		transform.localScale = noteScale;//WHY ISN"T THIS SCALING WORKING?										???			???

		

		//Each Note has their own
		if (NoteDirection.Equals(SwipeDirection.Down))
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Down;
		}
		else if (NoteDirection.Equals(SwipeDirection.Up))
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Up;
		}
		else if (NoteDirection.Equals(SwipeDirection.Right))
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Right;
		}
		else if (NoteDirection.Equals(SwipeDirection.Left))
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Left;
		}
		else if (NoteDirection.Equals(SwipeDirection.DownLeft))
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = dLeft;
		}
		else if (NoteDirection.Equals(SwipeDirection.UpLeft))
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = uLeft;
		}
		else if (NoteDirection.Equals(SwipeDirection.UpRight))
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = uRight;
		}
		else if (NoteDirection.Equals(SwipeDirection.DownRight))
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = uRight;
		}
		else{
			
		}

	}


    //==============================================================================================================================

    // Update is called once per frame
    void Update () {
		
		if (active)
		{
			rb.isKinematic = false;//freeze the note
								  //Set Note position here?
								  //this.RigidBody.velocity = Vector3.zero;

			//this.rb.velocity = Vector3.zero;
		}


		
		
		
	}





	//==============================================================================================================================

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Note" || collision.gameObject.tag == "NoteStopper" || collision.gameObject.tag == "BestNote")
		{
			noteStuff = collision.gameObject;
			active = true;


			//set position to spot at where it started colliding
		}
	}


	//==============================================================================================================================

	public SwipeDirection CreateRndDirection()
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
