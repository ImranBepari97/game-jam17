using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusScript : MonoBehaviour
{
    [SerializeField] float waitTime;// time to wait at stop
    [SerializeField] float leaveTime;// time from leaving bus stop until end of journey
    [SerializeField] float waitPos;// X coordinate at which to stop
    private float speed;
    Vector3 startPlace;
    bool isStopped = false;
    bool hasWaited = false;
    BusStop busStop;
    float elapsedTime = 0f;// time since start of last phase of journey

    public float speedModifier;

    // Use this for initialization
    void Start()
    {
        speed = 3;
        startPlace = transform.position;
    }
    
    void Awake()
    {
        busStop = FindObjectOfType<BusStop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < waitPos)
        {
            // not yet arrived at bus stop
            transform.Translate(speedModifier * speed * Time.deltaTime, 0, 0);
        }
        else
        {
            elapsedTime += Time.deltaTime;
            if (!hasWaited)
            {
                // waiting at bus stop
                if (elapsedTime >= waitTime)
                {
                    // stop waiting
                    elapsedTime = 0f;
                    isStopped = false;
                    hasWaited = true;
                }
                else
                {
                    busStop.PutPeopleOnBus();
                    isStopped = true;
                }
            }
            else
            {
                // leaving
                transform.Translate(speedModifier * speed * Time.deltaTime, 0, 0);
                if (elapsedTime >= leaveTime)
                {
                    // return to start
                    elapsedTime = 0f;
                    transform.position = startPlace;
                    hasWaited = false;
                }
            }
        }
    }

    //On entering the bus radius
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Person")
        {
            if (isStopped)
            {
                // bus is stopped; put the person on the bus
                busStop.PutPersonOnBus(collision.gameObject);
            }
            else
            {
                // bus is moving; kill the person
                collision.gameObject.GetComponent<Person>().Die();
            }
        }
    }
}
