using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public AudioSource stopSound;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        transform.Translate(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.F))
        {
            stopSound.Play();
        }
    }

    void awake()
    {
       stopSound = GetComponent<AudioSource>();
    }
}
