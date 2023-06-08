using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public Sprite emptyHarth;
    public Sprite fullHearth;
    public Image[] hearths;

    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.maxHealth;
        maxHealth = playerHealth.maxHealth;
        for (int i = 0; i < hearths.Length; i++)
        {
            if (i < maxHealth)
            {
                hearths[i].sprite = fullHearth;
            }
            else
            {
                hearths[i].sprite = emptyHarth;
            }
        }
    }
}
