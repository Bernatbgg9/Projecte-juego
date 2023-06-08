using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static float scoreValue = 500;
    public float scoreDecreasePerSecond; 

    Text score;

    private void Start()
    {
        score = GetComponent<Text>();
        scoreDecreasePerSecond = 2;
    }

    private void Update()
    {
        score.text = "Score: " + (int)scoreValue;
        scoreValue -= scoreDecreasePerSecond * Time.deltaTime;
    }
}
