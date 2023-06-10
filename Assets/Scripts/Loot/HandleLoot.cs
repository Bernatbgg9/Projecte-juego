using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLoot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.PlaySFX("HealSound");
            collision.gameObject.GetComponent<PlayerHealth>().Heal(1);
            Destroy(gameObject);
        }
    }
}
