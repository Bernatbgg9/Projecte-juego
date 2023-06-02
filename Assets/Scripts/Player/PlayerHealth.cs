using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public Image healthBar;
    public Animator Animator;
    public GameManagerScript gameManager;
    public GameObject weapon;

    private bool isDead;

    void Start()
    {
        Animator = GetComponent<Animator>();

        health = maxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0 && !isDead)
        {
            isDead = true;
            weapon.SetActive(false);
            gameObject.SetActive(false);
            gameManager.GameOver();
            //Animator.SetTrigger("Death");
        }
    }

    /*public void Death()
    {
        gameObject.SetActive(false);
        gameManager.GameOver();
    }*/
}
