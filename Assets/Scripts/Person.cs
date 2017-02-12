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
    [SerializeField] RuntimeAnimatorController[] personAnimatorControllers;// animator controllers for people of different views
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    [SerializeField] int fightCooldown;
    [SerializeField] AudioClip deathClip;

    bool canFight;
    FightRadius fightRadius;
    Vector3 drunkDir;//direction change caused by drunkness
    Vector3 beaconPos;//position of crossing beacon
    Animator anim;

    public Vector3 target;//movement destination
    public Person fighting = null;//who is this person fighting right now?
    public Slider slider;

    void Awake()
    {
        anim = GetComponent<Animator>();
        fightRadius = GetComponentInChildren<FightRadius>();
        beaconPos = FindObjectOfType<CrossingBeacon>().transform.position;
    }

    // Use this for initialization
    void Start ()
    {
        //sets drunkness and view values in the given range
        currentDrunkness = Random.Range(minDrunkness, maxDrunkness + 1);
        view = Random.Range(minView, maxView + 1);
        anim.runtimeAnimatorController = personAnimatorControllers[view - minView];
        canFight = true;
        maxHealth = 1000;
        currentHealth = 1000;
        fightCooldown = 5;
        target = beaconPos;
        StartCoroutine(ChangeDirection());
    }

    // Calculate the probability of starting a fight with another person.
    public void CheckStartFight(Person other)
    {
        if (fighting == null && canFight && other.fighting == null)
        {
            float distChance = 1 - Vector2.Distance(transform.position, other.transform.position) / (fightRadius.col.radius * transform.localScale.x);
            float viewChance = (float)Mathf.Abs(view - other.view) / (maxView - minView);
            float drunkChance = baseDrunkChance + (float)currentDrunkness / (maxDrunkness - minDrunkness) * (1 - baseDrunkChance);
            float chance = 1 - Mathf.Pow(1 - distChance * viewChance * drunkChance, Time.fixedDeltaTime);

            if (Random.value < chance)
            {
                StartFighting(other);
                other.StartFighting(this);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fighting == null)
        {
            anim.SetBool("fighting", false);
            transform.Translate(((target - transform.position).normalized * speed + drunkDir).normalized * speed * Time.deltaTime);
            if (currentHealth < maxHealth)
            {
                currentHealth += 1;
            }
        } else
        {
            currentHealth -= 1;
        }

        if(currentHealth == 0)
        {
            Die();
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

    public void StartFighting(Person other)
    {
        fighting = other;
        anim.SetBool("fighting", true);
    }

    public void StopFighting()
    {
        fighting = null;
        fightRadius.sr.enabled = false;
        anim.SetBool("fighting", false);
        canFight = false;
        StartCoroutine(FightCooldown());
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

    IEnumerator FightCooldown()
    {
        yield return new WaitForSeconds(fightCooldown);
        canFight = true;
    }

    public void Die()
    {
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position);
        Destroy(gameObject);
    }
}