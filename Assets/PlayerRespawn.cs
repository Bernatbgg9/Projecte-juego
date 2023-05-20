using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject[] Corazones;
    private int life;
    private float checkPointPositionX, checkPointPositionY;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        life = Corazones.Length;

        if (PlayerPrefs.GetFloat("checkPointPositionX")!= 0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionT")));
        }
    }
    private void Update()
    {
        if (life <  1)
        {
            Destroy(Corazones[0].gameObject);
            animator.Play("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (life < 2)
        {
            Destroy(Corazones[1].gameObject);
            animator.Play("Hit");
        }
        else if (life < 3)
        {
            Destroy(Corazones[2].gameObject);
            animator.Play("Hit");
        }
    }

    public void ReachedCheckPoint (float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    // Update is called once per frame
    public  void PlayerDamaged()
    {
        //animator.Play("Hit");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        life--;
    }
}
