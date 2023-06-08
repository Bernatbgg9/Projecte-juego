using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private bool isDead;

    public EnemyHealthBar healthBar;
    public Animator Animator;
    public GameObject Bar;
    public CameraShake cameraShake;

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

        if (currentHealth <= 0 && !isDead)
        {
            if (gameObject.CompareTag("Turret"))
            {
                PlayerScore.scoreValue += 100;
            }

            if (gameObject.CompareTag("Enemy"))
            {
                PlayerScore.scoreValue += 50;
            }
            
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

    public void ShakeExplosion()
    {
        StartCoroutine(cameraShake.Shake(0.15f, 0.25f));
    }
}
