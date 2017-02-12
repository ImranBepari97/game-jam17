using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Christian : MonoBehaviour {

    Vector3 startPlace;
    public float speed;
    public float speedModifier;
    int time;

    // Use this for initialization
    void Start () {
        speed = 1;
        startPlace = transform.position;
        time = 0;
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(speedModifier * speed * Time.deltaTime, 0, 0);


        if (time > 4000)
        {
            time = 0;
            transform.position = startPlace;
        }
        time++;

    }
}
