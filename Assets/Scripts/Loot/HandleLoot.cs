using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLoot : MonoBehaviour
{
    public GameObject m4;
    public GameObject pistol;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {          
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("ey");
                m4.SetActive(false);
                pistol.SetActive(true);
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
