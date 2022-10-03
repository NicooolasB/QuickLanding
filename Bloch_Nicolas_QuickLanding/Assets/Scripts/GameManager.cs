using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject obstacle;
    public TextMeshProUGUI rewardText;
    public GameObject playButton;
    public GameObject nextButton;
    public GameObject pauseButton;
    public GameObject playAgainButton;
    public GameObject player;
    public GameObject joystick;


    
    private void finalLevel ()
    {
        int compteur =  0;
        while(compteur < 3){
            float positionX = Random.Range(-8f,8f);
            float positionY = Random.Range(5f,14f);
            float positionZ = Random.Range(25f,60f);
            Instantiate(obstacle, new Vector3(positionX, positionY, positionZ) ,Quaternion.identity);
            compteur ++;
        }
    }

    private void Awake() {
        pauseButton.SetActive(false);
        if(SceneManager.GetActiveScene().buildIndex > 0){
            rewardText.enabled = false;
            if(SceneManager.GetActiveScene().buildIndex == 3){
                finalLevel(); 
            }
        }
        
    }


    public void GameStart()
    {
        playButton.SetActive(false);
        pauseButton.SetActive(true);
        rewardText.enabled = false;
        player.SetActive(true);
        joystick.SetActive(true);
    }

    public void GameFinish(string finalZone){
        if (finalZone == "Zone1" || finalZone == "Zone3"){
            rewardText.text = "Nice Job";
            rewardText.color = new Color32(255, 215, 0, 255);
            GameWon();

        }
        else if (finalZone == "Zone2"){
            rewardText.text = "Awesome";
            rewardText.color = new Color32(50, 205, 50, 255);
            GameWon();
        }
        else{
            rewardText.text = "Try Again";
            rewardText.color = new Color32(73, 12, 3, 255);
            GameLost();
        }
    }

    private void GameWon() 
    {
        pauseButton.SetActive(false);
        rewardText.enabled = true;
        //player.SetActive(true);
        joystick.SetActive(false);
        nextButton.SetActive(true);
    }

    public void nextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex < 3){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
        //this give us the possibility to have a new aleatory level 3
        else{
            playAgain();
        }
        
    }

    private void GameLost()
    {
        pauseButton.SetActive(false);
        rewardText.enabled = true;
        //player.SetActive(true);
        playAgainButton.SetActive(true);
        joystick.SetActive(false);
    }

    public void playAgain()
    {
        Time.timeScale = 1f;
        PauseMenu.GameIsPause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }


}
