using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLoot : MonoBehaviour
{
    //public GameObject m4;
    //public GameObject pistol;
    PlayerShooting playerShooting;

    private void Start()
    {
        playerShooting = GetComponentInChildren<PlayerShooting>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerShooting.ChangeWeapon();
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Loot"))
        {
            if (PlayerHealth.currentHealth < 5)
            {
                AudioManager.PlaySFX("HealSound");
                gameObject.GetComponent<PlayerHealth>().Heal(1);
                Destroy(collision.gameObject);
            }
        }
    }
}
