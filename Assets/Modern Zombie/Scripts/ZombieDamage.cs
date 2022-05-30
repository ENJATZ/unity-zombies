using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using TMPro;

public class ZombieDamage : Damageable
{
    public NavMeshAgent zombie;
    public Animator animator;
    public GameObject healthPickupObject;
    public GameObject bulletsBoxObject;
    public GameObject droppableRifle;
    public GameObject droppableShotgun;
    public GameObject droppableRPG;
    public GameObject droppableMinigun;

    float hurt = 0f;
    float previousHealth;
    TextMeshProUGUI score;
    TimerController timerController;

    public override void Start()
    {
        base.Start();
        previousHealth = health;
        score = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        timerController = GameObject.Find("Timer").GetComponent<TimerController>();
        AddCallOnDamage(HurtTarget);
        AddCallOnDeath(TargetDied);
    }

    public override void Update()
    {
    }

    void HurtTarget()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Damage Torso")) {
            animator.Play("Damage Torso", 0, 0);
        }
        if (isDead()) return;
        float dmgDone = (previousHealth - health);
        hurt = dmgDone / (maxHealth * 2);
    }
    void DisableColliders () {
        foreach(Collider c in GetComponentsInChildren<Collider> ()) {
            c.enabled = false;
        }
    }
    void TargetDied()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Fall Backward")) {
            animator.Play("Fall Backward", 0, 0);
        }
        int newScore = int.Parse(score.text) + 1;
        score.SetText(newScore.ToString());
        GlobalVariables.score++;
        DisableColliders();

        int chosenPickup = 0;
        if(Random.value > 0.7) {
            chosenPickup = 1;
        }
        if(Random.value > 0.6) {
            chosenPickup = 2;
        }
        switch(chosenPickup) {
            case 1:
                GameObject healthPickup = Instantiate(healthPickupObject, new Vector3(0, 0.7f, 0) + gameObject.transform.position, Quaternion.identity);
                healthPickup.transform.Rotate(-90, 0, 0);
            break;
            case 2:
                GameObject bulletsPickup = Instantiate(bulletsBoxObject, new Vector3(0, 0.3f, 0.3f) + gameObject.transform.position, Quaternion.identity);
            break;
        }

        float timeElapsed = timerController.GetElapsedTime();

        int chosenGun = 0;
        if(timeElapsed >= 20) {
            if(Random.value > 0.65) {
                chosenGun = 1;
            }
        }
        if(timeElapsed >= 40) {
            if(Random.value > 0.7) {
                chosenGun = 2;
            }
        } 
        if(timeElapsed >= 100) {
            if(Random.value > 0.75) {
                chosenGun = 3;
            }
        }
        if(timeElapsed >= 120) {
            if(Random.value > 0.8) {
                chosenGun = 4;
            }
        }
        switch(chosenGun) {
            case 1: 
                Instantiate(droppableRifle, new Vector3(0, 0.3f, 0.3f) + gameObject.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(droppableShotgun, new Vector3(0, 0.3f, 0.3f) + gameObject.transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(droppableMinigun, new Vector3(0, 0.3f, 0.3f) + gameObject.transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(droppableRPG, new Vector3(0, 0.3f, 0.3f) + gameObject.transform.position, Quaternion.identity);
                break;
        }
    }

    
}
