using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightRadius : MonoBehaviour {
    [SerializeField] float breakUpHoldTime;//time player must hold F to break up a fight

    Person person;// the person this radius belongs to
    float fHeldTime = 0f;// time player has held F
    bool beingStopped = false;// is the player stopping a fight here now?
    PlayerController player;

    public SpriteRenderer sr;//renderer for key prompt sprite
    public CircleCollider2D col;//this object's collider

    void Awake()
    {
        person = GetComponentInParent<Person>();
        sr = GetComponentInChildren<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (sr.enabled && person.fighting != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                beingStopped = true;
                player.PlayStopSound();
                fHeldTime = 0f;// reset timer
            }
            if (beingStopped)
            {
                if (fHeldTime >= breakUpHoldTime)
                {
                    // player breaks up fight
                    person.fighting.StopFighting();
                    person.StopFighting();
                    fHeldTime = 0f;// reset timer
                    beingStopped = false;
                }
                else if (Input.GetKey(KeyCode.F))
                {
                    // increment timer
                    fHeldTime += Time.deltaTime;
                }
                else
                {
                    fHeldTime = 0f;// reset timer
                    beingStopped = false;
                }
            }
        }
        else
        {
            fHeldTime = 0f;// reset timer
            beingStopped = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (person.fighting)
        {
            if (other.tag == "Player")
            {
                //show prompt to break up fight
                sr.enabled = true;
            }
        }
        else
        {
            Person otherPerson = other.GetComponent<Person>();
            if (otherPerson != null)
            {
                person.CheckStartFight(otherPerson);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // disable prompt
            sr.enabled = false;

            fHeldTime = 0f;// reset timer
            beingStopped = false;
        }
    }
}
