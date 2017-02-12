using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveScript : MonoBehaviour {
    public int wave = 1;
    GameController gc; //create new gamecontroller reference

    void Awake()
    {
        gc = FindObjectOfType<GameController>(); //find object
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        updateWave();
       // Debug.Log("current wave:" + wave);
    }

    void updateWave()
    {

        if (gc.score >= 5 * wave)
        {
            wave++;
        }

    }
}
