using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusScript : MonoBehaviour
{
    [SerializeField] float waitTime;// time to wait at stop
    [SerializeField] float leaveTime;// time from leaving bus stop until end of journey
    [SerializeField] float waitPos;// X coordinate at which to stop
    int time;
    private float speed;
    Vector3 startPlace;
    bool isStopped = false;
    bool hasWaited = false;
    GameController gc;
    float elapsedTime = 0f;// time since start of last phase of journey

    public float speedModifier;

    // Use this for initialization
    void Start()
    {
        time = 0;
        speed = 3;
        startPlace = transform.position;
    }
    
    void Awake()
    {
        gc = FindObjectOfType<GameController>();
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
                Destroy(collision.gameObject);
                gc.score += 1;
            }
            else
            {
                collision.gameObject.GetComponent<Person>().Die();
            }
        }
    }
}
