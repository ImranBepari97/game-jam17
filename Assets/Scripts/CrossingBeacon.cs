using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossingBeacon : MonoBehaviour {

    [SerializeField] Transform busStop;

    SpriteRenderer sr;
    PlayerController player;
    List<Person> peopleOnBeacon; //people who have arrived at this beacon

    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        peopleOnBeacon = new List<Person>();
        player = FindObjectOfType<PlayerController>();
    }

	// Update is called once per frame
	void Update () {
		if (sr.enabled && Input.GetKeyDown(KeyCode.F))
        {
            player.PlayGoSound();
            // player pressed F; change people's target
            foreach (Person person in peopleOnBeacon)
            {
                if (person != null)
                {
                    person.target = busStop.position;
                    person.canFight = false;
                    person.gameObject.layer = LayerMask.NameToLayer("Default");//disable person collision with street
                }
            }
            peopleOnBeacon.Clear();
        }
	}

    //On entering the hitbox radius
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            sr.enabled = true;
        }
        else
        {
            Person newPerson = other.GetComponent<Person>();
            if (newPerson != null && !peopleOnBeacon.Contains(newPerson))
            {
                peopleOnBeacon.Add(newPerson);
            }
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            sr.enabled = false;
        }
    }

    
}
