using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personController : MonoBehaviour {

    public bool isDead = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead){
            Destroy(gameObject);
        }
	}
}
