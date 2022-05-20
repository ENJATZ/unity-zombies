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
    
    float hurt = 0f;
    float previousHealth;
    TextMeshProUGUI score;

    public override void Start()
    {
        base.Start();
        previousHealth = health;
        score = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
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

    void TargetDied()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Fall Backward")) {
            animator.Play("Fall Backward", 0, 0);
        }
        int newScore = int.Parse(score.text) + 1;
        score.SetText(newScore.ToString());
    }

    
}
