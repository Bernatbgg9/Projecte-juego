using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gamePausedUI;
    public GameObject pauseButton;
    public GameObject healthBar;
    public GameObject minimap;

    private bool isPaused = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }

            else
            {
                Resume();
            }
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        gamePausedUI.SetActive(true);
        pauseButton.SetActive(false);
        minimap.SetActive(false);
        healthBar.SetActive(false);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        gamePausedUI.SetActive(false);
        pauseButton.SetActive(true);
        minimap.SetActive(true);
        healthBar.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuInic");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
