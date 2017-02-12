using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {
    [SerializeField]
    public int maxObjects;

    [SerializeField]
    GameObject personPrefab;

    [SerializeField]
    float timeGap;
    float curTime;

    public void spawn()
    {
        if (checkObjects() == true) {
            Instantiate(personPrefab, transform.position, transform.rotation);
        }
        

    }

   public bool checkObjects( )
    {

        GameObject[] people = GameObject.FindGameObjectsWithTag("Person");
        int numberOfNPCS = people.Length;

        if (people.Length < maxObjects){

            return true;
        } else{
            return false;
        }
    }

    // Use this for initialization
    void Start () {
        maxObjects = 15; //default value on start
        timeGap = 3;
        curTime = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (curTime > timeGap)
        {
            spawn();
            curTime = 0;
        }

        curTime+=Time.deltaTime;
	}
}
