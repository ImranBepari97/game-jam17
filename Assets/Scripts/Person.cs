using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person : MonoBehaviour {

    [SerializeField]
    int currentDrunkness;
    [SerializeField]
    int minDrunkness;
    [SerializeField]
    int maxDrunkness;
    [SerializeField]
    int minView;
    [SerializeField]
    int maxView;
    [SerializeField]
    float baseDrunkChance; //base probability of starting a fight when at minDrunkness
    [SerializeField]
    float probabilityScale;//multiply fight probability by this amount every check

    CircleCollider2D fightCollider;

    public int view;
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

    // Update is called once per frame
    void Update()
    {
        addRevolution(5F);
    }

    void addRevolution(float num)
    {
        slider.value = slider.value + num;
    }
}
