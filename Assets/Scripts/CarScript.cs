using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {
    int time;
    public float speedModifier;
    public float speed;
    Vector3 startPlace;

    // Use this for initialization
    void Start () {
        time = 0;
        speed = 3;
        startPlace = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speedModifier * speed * Time.deltaTime, 0, 0);


        if (time > 1000)
        {
            time = 0;
            Destroy(gameObject);
        }
        time++;

    }
}
