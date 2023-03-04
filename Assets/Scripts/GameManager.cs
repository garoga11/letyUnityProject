using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject gamePanel;
    public Vector3 startingPosition;
    public int scoreToWin = 345;
    public Text gameText;
    public AudioSource music;


    void Start(){
         gamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        if (playerController.hasFallen)
        {
            Time.timeScale = 0f; // pause the game
            music.Stop();

            gamePanel.SetActive(true); // show the Game Over panel
            
            // Set the winText to include the player's score
            gameText.text = "Game Over! your score is: " + playerController.score;


        }else if(playerController.score >= scoreToWin){
            music.Stop();

            // Display the win panel
            gamePanel.SetActive(true); // show the Game Over panel

            // Set the winText to include the player's score
            gameText.text = "You passed the level! score: " + playerController.score;

            // Pause the game
            Time.timeScale = 0f;
        }
        
    }

    public void RestartGame()
    {
        Debug.Log("Restarting Game");
        
        // Reload the current scene to restart the game
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

        // Reset the player's position and velocity
        playerController.transform.position = startingPosition;
        playerController.GetComponent<Rigidbody>().velocity = Vector3.zero;

        // Unpause the game
        Time.timeScale = 1f;

        //Reset score
        playerController.score = 0;
    }
}
