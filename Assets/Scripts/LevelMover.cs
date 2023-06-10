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
    public Animator transitionAnim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //playerStorage.spawnValue = playerPos;
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("End");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadSceneAsync(sceneToLoad /*, LoadSceneMode.Single*/);
    }
}
