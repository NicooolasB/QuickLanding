using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause;
    public GameObject pauseMenuUI;
    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject playAgainButton;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        playAgainButton.SetActive(false);

    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
        playButton.SetActive(true);
        pauseButton.SetActive(false);
        playAgainButton.SetActive(true);

    }
    
}
