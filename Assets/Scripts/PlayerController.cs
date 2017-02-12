using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] AudioSource stopSound;
    [SerializeField] AudioSource goSound;

    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        transform.Translate(0, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);
    }

    public void PlayStopSound()
    {
        if (!stopSound.isPlaying)
        {
            stopSound.Play();
        }
    }

    public void PlayGoSound()
    {
        if (!goSound.isPlaying)
        {
            goSound.Play();
        }
    }
}
