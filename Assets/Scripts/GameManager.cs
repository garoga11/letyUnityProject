using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject gameOverPanel;
    public Vector3 startingPosition;
    public int scoreToWin = 345;

    public Text winText;
    public Text gameOverText;

    void Start(){
         gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if (playerController.hasFallen)
        {
            Time.timeScale = 0f; // pause the game

            gameOverPanel.SetActive(true); // show the Game Over panel
            
            // Set the winText to include the player's score
            gameOverText.text = "Game Over! your score is: " + playerController.score;


        }else if(playerController.score >= scoreToWin){

            // Display the win panel
            gameOverPanel.SetActive(true); // show the Game Over panel

            // Set the winText to include the player's score
            gameOverText.text = "You passed the level! score: " + playerController.score;

            // Pause the game
            Time.timeScale = 0f;
        }
        
    }

    public void RestartGame(){
        Debug.Log("Restarting");
        playerController.transform.position = startingPosition;

        gameOverPanel.SetActive(false);
    }
}
