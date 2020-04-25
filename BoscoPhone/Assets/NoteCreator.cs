using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCreator : MonoBehaviour
{
    public Note noteClass = new Note();
    public GameObject notePrefab;
    private Vector2 itemBound;

	private float timer = 0;
	private float timerMax = 0;
	private int noteCounter = 0;


	//Get object position Stuff
	public Transform targetCreator;
    
    ArrayList noteList = new ArrayList();


	// Start is called before the first frame update
	void Start()
	{

		for (noteCounter= 0; noteCounter < 7; noteCounter++)
		{
			//NEED to make the spawning wait a certain amount of time. 
			SpawnNote();
			Waited(5);//Does the game need this wait?
		}
    }

    /*private void Instantiate(Note noteClass, GameObject[] gameObject)
    {
        
        throw new NotImplementedException();
    }*/

    // Update is called once per frame
    void Update()
    {
       if(noteCounter != 7)
		{
			SpawnNote();
		}
    }



    private void SpawnNote()
    {
        GameObject a = Instantiate(notePrefab) as GameObject;//added to scene
        a.transform.position = targetCreator.position;
		
    }



	private bool Waited(float seconds)
	{
		timerMax = seconds;

		timer += Time.deltaTime;

		if(timer >= timerMax)
		{
			return true; //max reached - waited x - seconds
		}

		return false;
	}


}
