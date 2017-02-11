using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightRadius : MonoBehaviour {
    Person person;// the person this radius belongs to

    void Awake()
    {
        person = GetComponentInParent<Person>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Person otherPerson = other.GetComponent<Person>();
        if (otherPerson != null)
        {
            person.CheckStartFight(otherPerson);
        }
    }
}
