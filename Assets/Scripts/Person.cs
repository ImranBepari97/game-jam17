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
    [SerializeField] float baseDrunkChance; //base probability of starting a fight when at minDrunkness
    [SerializeField] int view;
    [SerializeField] float speed;
    [SerializeField] float directionChangeIntervalScale;
    [SerializeField] float drunkDirScale;
    FightRadius fightRadius;
    Vector3 drunkDir;//direction change caused by drunkness
    Vector3 beaconPos;//position of crossing beacon

    public Vector3 target;//movement destination
    public Person fighting = null;//who is this person fighting right now?
    public Slider slider;

    void Awake()
    {
        fightRadius = GetComponentInChildren<FightRadius>();
        beaconPos = FindObjectOfType<CrossingBeacon>().transform.position;
    }

    // Use this for initialization
    void Start ()
    {
        //sets drunkness and view values in the given range
        currentDrunkness = Random.Range(minDrunkness, maxDrunkness);
        view = Random.Range(minView, maxView);

        target = beaconPos;
        StartCoroutine(ChangeDirection());
    }

    // Calculate the probability of starting a fight with another person.
    public void CheckStartFight(Person other)
    {
        if (fighting == null)
        {
            float distChance = 1 - Vector2.Distance(transform.position, other.transform.position) / (fightRadius.col.radius * transform.localScale.x);
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
        if (fighting == null)
        {
            transform.Translate(((target - transform.position).normalized * speed + drunkDir).normalized * speed * Time.deltaTime);
        }
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

    public void StopFighting()
    {
        fighting = null;
        fightRadius.sr.enabled = false;
    }

    //direction change caused by drunkness
    IEnumerator ChangeDirection()
    {
        while (true)
        {
            drunkDir = Random.insideUnitCircle * currentDrunkness * drunkDirScale;
            yield return new WaitForSeconds((maxDrunkness - currentDrunkness + 1) * directionChangeIntervalScale);
        }
    }

    //On entering the person radius
    void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.tag == "Person")
            {

            }
    }
}
