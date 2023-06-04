using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private bool isDead;

    public EnemyHealthBar healthBar;
    public Animator Animator;
    public GameObject Bar;

    void Start()
    {
        Animator = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth, maxHealth);

        if (currentHealth < 0 && !isDead)
        {
            isDead = true;
            Bar.SetActive(false);
            Animator.SetTrigger("Death");
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void EnemyDeathSound()
    {
        AudioManager.PlaySFX("EnemyDeath");
    }

    public void TurretSound()
    {
        AudioManager.PlaySFX("TurretExplosion");
    }
}
