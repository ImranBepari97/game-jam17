using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusScript : MonoBehaviour
{
    int time;
    public float speedModifier;
    private float speed;
    Vector3 startPlace;
    bool hasWaited;

    // Use this for initialization
    void Start()
    {
        time = 0;
        speed = 3;
        startPlace = transform.position;
        hasWaited = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (transform.position.x < 7 && hasWaited == false)
        {
            transform.Translate(speedModifier * speed * Time.deltaTime, 0, 0);
        }
        if (transform.position.x >= 7)
        {
            hasWaited = true;
            time++;
        }
        if (transform.position.x >= 7 && time > 400)
        {
            transform.Translate(speedModifier * speed * Time.deltaTime, 0, 0);
            time++;
            if (time > 1000)
            {
                hasWaited = false;
                time = 0;
                transform.position = startPlace;
            }
        }
    }
}
