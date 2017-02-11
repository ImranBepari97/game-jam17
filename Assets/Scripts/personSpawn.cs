using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personSpawn : MonoBehaviour {

    [SerializeField]
    GameObject personPrefab;

    public void spawn()
    {
        Instantiate(personPrefab, transform);

    }

	// Use this for initialization
	void Start () {
       // Instantiate(person);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
