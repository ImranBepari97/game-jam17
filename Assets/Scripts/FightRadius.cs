using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightRadius : MonoBehaviour {
    Person person;// the person this radius belongs to

    public SpriteRenderer sr;//renderer for key prompt sprite
    public CircleCollider2D col;//this object's collider

    void Awake()
    {
        person = GetComponentInParent<Person>();
        sr = GetComponentInChildren<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (sr.enabled && Input.GetKeyDown(KeyCode.F) && person.fighting != null)
        {
            // player breaks up fight
            person.fighting.StopFighting();
            person.StopFighting();
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
        }
    }
}
