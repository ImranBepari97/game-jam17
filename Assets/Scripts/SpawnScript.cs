using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour {

    [SerializeField]
    GameObject personPrefab;

    [SerializeField]
    float timeGap;
    float curTime;

    public void spawn()
    {
        Instantiate(personPrefab, transform.position, transform.rotation);

    }

   

    // Use this for initialization
    void Start () {
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
