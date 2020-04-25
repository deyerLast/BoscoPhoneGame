using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCreator : MonoBehaviour
{
    public Note noteClass = new Note();
    public GameObject notePrefab;
    private Vector2 itemBound;

    //Get object position Stuff
    public Transform targetCreator;
    
    ArrayList noteList = new ArrayList();


    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < 7; i++)
        {
            //NEED to make the spawning wait a certain amount of time. 
            SpawnNote();
        }
    }

    /*private void Instantiate(Note noteClass, GameObject[] gameObject)
    {
        
        throw new NotImplementedException();
    }*/

    // Update is called once per frame
    void Update()
    {
       
    }

    private void SpawnNote()
    {
        GameObject a = Instantiate(notePrefab) as GameObject;//added to scene
        a.transform.position = targetCreator.position;
		
    }


}
