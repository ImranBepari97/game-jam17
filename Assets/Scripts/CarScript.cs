﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {
    int time;
    public float speedModifier;
    public float speed;

    // Use this for initialization
    void Start () {
        time = 0;
        speed = 3;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speedModifier * speed * Time.deltaTime, 0, 0);


        if (time > 5000)
        {
            time = 0;
            Destroy(gameObject);
        }
        time++;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Vehicle")
        {
            speed = 0;
        }

        else
        {
            speed = 3;
        }

        if (collision.gameObject.tag == "Person")
        {
            collision.gameObject.GetComponent<Person>().Die();
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
