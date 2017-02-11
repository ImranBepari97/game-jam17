using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Person : MonoBehaviour {

    [SerializeField] int currentDrunkness;
    [SerializeField] int minDrunkness;
    [SerializeField] int maxDrunkness;
    [SerializeField] int minView;
    [SerializeField] int maxView;
    [SerializeField] float baseDrunkChance; //base probability of starting a fight when at minDrunkness
    [SerializeField]
    float probabilityScale;//multiply fight probability by this amount every check
    [SerializeField] int view;
    Vector3 randomDestination;
    CircleCollider2D fightCollider;

    public Person fighting = null;//who is this person fighting right now?
    public Slider slider;

    void Awake()
    {
        fightCollider = GetComponentInChildren<CircleCollider2D>();
    }

    // Use this for initialization
    void Start ()
    {
        //sets drunkness and view values in the given range
        currentDrunkness = Random.Range(minDrunkness, maxDrunkness);
        view = Random.Range(minView, maxView);
    }

    // Calculate the probability of starting a fight with another person.
    public void CheckStartFight(Person other)
    {
        if (fighting == null)
        {
            float distChance = 1 - Vector2.Distance(transform.position, other.transform.position) / fightCollider.radius;
            float viewChance = (float)Mathf.Abs(view - other.view) / (maxView - minView);
            float drunkChance = baseDrunkChance + (float)currentDrunkness / (maxDrunkness - minDrunkness) * (1 - baseDrunkChance);
            float chance = 1 - Mathf.Pow(1 - distChance * viewChance * drunkChance, Time.fixedDeltaTime);
            if (Random.value < chance)
            {
                fighting = other;
                other.fighting = this;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        randomDestination = new Vector3(Random.Range(0, 5), Random.Range(0, 5));
        moveTo(randomDestination);
    }

    void addRevolution(float num)
    {
        slider.value = slider.value + num;

        if (slider.value == slider.maxValue || slider.value > slider.maxValue)
        {
            SceneManager.LoadScene("GameOver");
        }
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
