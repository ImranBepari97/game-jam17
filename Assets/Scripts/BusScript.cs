using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusScript : MonoBehaviour
{
    int time;
    public float speed;
    Vector3 startPlace;

    // Use this for initialization
    void Start()
    {
        time = 0;
        speed = 3;
        startPlace = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        time++;
        if(time == 1)
        {
            speed = 3;
        }
        if (time == 200)
        {
            speed = 0;
        }
        if (time == 350)
        {
            speed = 3;
        }
        if (time == 650)
        {
            speed = 0;
            transform.position = startPlace;
        }
        if(time == 800)
        {
            time = 0;
        }
    }
}
