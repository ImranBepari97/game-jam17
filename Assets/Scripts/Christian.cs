using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Christian : MonoBehaviour {

    public float speed;
    public int biscuitNo;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int move = Random.Range(1, 100);
        if (move < 15)
        {
            if (Random.Range(-1, 1) < 0)
            {
                transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(1 * speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
