using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person : MonoBehaviour {


    [SerializeField] int currentDrunkness;
    [SerializeField] int minDrunkness;
    [SerializeField] int maxDrunkness;
    [SerializeField] int minView;
    [SerializeField] int maxView;
    [SerializeField] int view;
    Vector3 randomDestination;
    public Slider slider;
    



    // Use this for initialization
    void Start() {
        //sets drunkness and view values in the given range
        currentDrunkness = Random.Range(minDrunkness, maxDrunkness);
        view = Random.Range(minView, maxView);
    }

    // Update is called once per frame
    void Update() {
        addRevolution(5F);
        randomDestination = new Vector3(Random.Range(0, 5), Random.Range(0, 5));
        moveTo(randomDestination);
    }

    void addRevolution(float num)
    {
        slider.value = slider.value + num;
    }

    void crossRoad(Transform destination)
    {
        bool roadCrossed = false;

        while(!roadCrossed)
        {

        }
        
    }

    void moveTo(Vector3 targetPosition )
    {
        Vector3 directionToGo = (targetPosition - transform.position).normalized;
        transform.Translate(directionToGo * Time.deltaTime * currentDrunkness);
    }
}
