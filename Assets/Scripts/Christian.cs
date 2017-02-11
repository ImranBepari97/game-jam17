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


        if (time > 1000)
        {
            time = 0;
            transform.position = startPlace;
        }
        time++;
        //int move = Random.Range(1, 100);
        //if (move < 15)
        //{
        //  if (Random.Range(-1, 1) < 0)
        //{
        //  transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        //}
        //else
        //{
        //  transform.Translate(1 * speed * Time.deltaTime, 0, 0);
        //}
        //}

    }
}
