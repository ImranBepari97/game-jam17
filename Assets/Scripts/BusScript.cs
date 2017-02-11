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
    bool isStopped;
    GameController gc;

    // Use this for initialization
    void Start()
    {
        Debug.Log("start");
        time = 0;
        speed = 3;
        startPlace = transform.position;
        hasWaited = false;
        isStopped = false;
    }
    
    void Awake()
    {
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopped)
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

    //On entering the bus radius
    void OnCollisionEnter2D(Collision2D collision)
    {

        
            if (collision.gameObject.tag == "Person")
            {
                Destroy(collision.gameObject);
                if (isStopped)
                {
                     gc.score += 1;
                }
            }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isStopped = false;
    }
}
