using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject gameOverPanel;
    public bool isGameOver = false;
    public Vector3 startingPosition;

    void Start(){
         gameOverPanel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (playerController.hasFallen)
        {
            Time.timeScale = 0f; // pause the game
            gameOverPanel.SetActive(true); // show the Game Over panel
        }
    }
}
