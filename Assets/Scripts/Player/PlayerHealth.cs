using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static float currentHealth = 5;
    public float maxHealth;

    public Image healthBar;
    //public Animator Animator;
    public GameManagerScript gameManager;
    public GameObject weapon;

    private bool isDead;

    void Start()
    {
        //Animator = GetComponent<Animator>();
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        AudioManager.PlaySFX("PlayerHit");

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            AudioManager.PlaySFX("PlayerDeath");
            weapon.SetActive(false);
            gameManager.GameOver();
            //Animator.SetTrigger("Death");
        }
    }

    public void HealDamage()
    {
        currentHealth = maxHealth;
    }

    /*public void Death()
    {
        gameObject.SetActive(false);
        gameManager.GameOver();
    }*/
}
