using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStop : MonoBehaviour {
    List<Person> peopleAtStop; //people who have arrived at this stop
    GameController gc;

    void Awake()
    {
        peopleAtStop = new List<Person>();
        gc = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // person arrives at the stop?
        Person newPerson = other.GetComponent<Person>();
        if (newPerson != null && !peopleAtStop.Contains(newPerson))
        {
            newPerson.gameObject.layer = LayerMask.NameToLayer("PersonAtStop");// disable person collision with bus
            peopleAtStop.Add(newPerson);
        }
    }

    // put one person on the bus
    public void PutPersonOnBus(GameObject person)
    {
        Destroy(person);
        gc.score += 1;
    }

    // put all the people at the stop on the bus
    public void PutPeopleOnBus()
    {
        foreach (Person person in peopleAtStop)
        {
            if (person != null)
            {
                PutPersonOnBus(person.gameObject);
            }
        }
        peopleAtStop.Clear();
    }
}
