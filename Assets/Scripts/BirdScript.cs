using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {

    public float speedModifier;
    int time;
    Vector3 startPlace;

    // Use this for initialization
    void Start () {
        startPlace = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > -15)
        {
            transform.Translate(-1 * speedModifier * Time.deltaTime, 0, 0);
        }
        if (transform.position.x <= -15)
        {
            transform.position = startPlace;
        }

    }
}
