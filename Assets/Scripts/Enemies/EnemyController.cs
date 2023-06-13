using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static int enemiesLevelOne = 4;
    public static int enemiesLevelTwo = 5;

    public List<GameObject> listOfOpponents = new List<GameObject>();

    private void Awake()
    {
        listOfOpponents.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        listOfOpponents.AddRange(GameObject.FindGameObjectsWithTag("Turret"));
    }

    private void Update()
    {
        if (enemiesLevelOne == 0)
        {
            foreach (GameObject enemy in listOfOpponents)
            {
                Destroy(enemy);
            }
        }
    }
}
