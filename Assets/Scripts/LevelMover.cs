using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMover : MonoBehaviour
{
    //public int sceneBuildIndex;
    public string sceneToLoad;
    public Vector2 playerPos;
    public VectorValue playerStorage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerStorage.initialValue = playerPos; 
            SceneManager.LoadScene(sceneToLoad /*, LoadSceneMode.Single*/);
        }
    }
}
