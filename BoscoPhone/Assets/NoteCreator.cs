using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCreator : MonoBehaviour
{
    public Note noteClass = new Note();
    public GameObject notePrefab;
    private Vector2 itemBound;

	private float timer = 0;         //My timer isn't working properly
	private float timerMax = 0;
	private int noteCounter = 0;


	//Get object position Stuff
	public Transform targetCreator;
    
    ArrayList noteList = new ArrayList();


	// Start is called before the first frame update
	void Start()
	{
		
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
			//Waited(115);
			SpawnNote();
			noteCounter++;
			//Waited(5);
		}
    }



    private void SpawnNote()
    {
		Waited(5);
        GameObject a = Instantiate(notePrefab) as GameObject;//added to scene
        a.transform.position = targetCreator.position;
		//Waited(2);
    }



	private bool Waited(float seconds)
	{
		timerMax = seconds;

		timer += Time.deltaTime;

		if(timer >= timerMax)
		{
			return false; //max reached - waited x - seconds
		}

		return true;
	}


}
