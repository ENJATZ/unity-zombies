using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieChase : MonoBehaviour
{
    public NavMeshAgent zombie;
    public GameObject player;
    public Animator animator;
    public AudioSource audioSource;
    
    DamageHandler damageHandler;

    Damageable damageable;
    void Start()
    {
        damageable = GetComponent<Damageable>();
        damageHandler = player.GetComponent<DamageHandler>();
    }

    void Update()
    {
        if(damageable.isDead()) return;

        zombie.SetDestination(player.transform.position);

        float distance = Vector3.Distance(player.transform.position, zombie.transform.position);

        if(distance <= 2.0f) {
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
                damageHandler.TakeDamage(5);
                animator.Play("Attack", 0, 0);
                audioSource.Play(0);
            }
            
        }
    }
}
