using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DamageHandler : MonoBehaviour
{
    public HealthBar healthBar;
    public int health;
    public SceneLoader sceneLoader;
    void Start()
    {
        this.health = 100;
    }

    public void AddPickUpHealth() {
        this.health += 10;
        if(this.health > 100) this.health = 100;
        healthBar.SetHealth(this.health);

    }
    public void TakeDamage(int damage)
    {
        this.health -= damage;
        if (this.health <= 0)
        {
            healthBar.SetHealth(0);
            TextMeshProUGUI score = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
            sceneLoader.PlayerDied(int.Parse(score.text));

        }
        else
        {
            healthBar.SetHealth(this.health);
        }
    }
}
