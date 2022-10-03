using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause;
    public GameObject pauseMenuUI;
    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject playAgainButton;
    public GameObject homeButton;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        pauseButton.SetActive(true);
        playButton.SetActive(false);
        playAgainButton.SetActive(false);
        homeButton.SetActive(false);

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        pauseButton.SetActive(false);
        playButton.SetActive(true);
        playAgainButton.SetActive(true);
        homeButton.SetActive(true);

    }

    public void FirstLevel()
    {
        Time.timeScale = 1f;
        PauseMenu.GameIsPause = false;
        SceneManager.LoadScene(0); 
    }
    
}
