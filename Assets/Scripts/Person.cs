using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {


    [SerializeField] int currentDrunkness;
    [SerializeField] int minDrunkness;
    [SerializeField] int maxDrunkness;
    [SerializeField] int minView;
    [SerializeField] int maxView;
    [SerializeField] int view;
    


	// Use this for initialization
	void Start () {
        //sets drunkness and view values in the given range
        currentDrunkness = Random.Range(minDrunkness, maxDrunkness);
        view = Random.Range(minDrunkness, maxDrunkness);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
