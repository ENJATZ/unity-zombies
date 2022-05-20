using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public HealthBar healthBar; 
    public int health;
    void Start()
    {
        this.health = 100;
    }

    public void TakeDamage(int damage) {
        this.health -= damage;
        if (this.health <= 0) {
            healthBar.SetHealth(0);
            this.health = 100; // schimbat cu die;
        }
        else {
            healthBar.SetHealth(this.health);
        }
    }
}
