using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossingBeacon : MonoBehaviour {

    SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		
	}
	
    //
    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        Debug.Log(sr);
    }

	// Update is called once per frame
	void Update () {
		
	}

    //On entering the hitbox radius
    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log(other);
        sr.enabled = true;
    }

    void OnTriggerExit2D (Collider2D other)
    {
        sr.enabled = false;
    }

    
}
