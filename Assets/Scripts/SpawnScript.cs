using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    [SerializeField]
    GameObject personPrefab;

    [SerializeField]
    int timeGap;
    int curTime;

    public void spawn()
    {
        Instantiate(personPrefab, transform);

    }

   

    // Use this for initialization
    void Start () {
        timeGap = 1000;
        curTime = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if (curTime > timeGap)
        {
            spawn();
            curTime = 0;
        }

        curTime++;
	}
}
