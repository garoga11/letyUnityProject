using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsHandler : MonoBehaviour
{

    public int fungoPoints = 5;
    public int applePoints = 3;
    public int ratPoints = 20;
    public int lizardPoints = 50;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        // Check if the collider is not null and has a PlayerController component
        if (other != null)
        {
            PlayerController playerScore = other.GetComponent<PlayerController>();
            if (playerScore != null)
            {
                // Get the tag of the current game object that is using this script
                string currentObjectTag = transform.gameObject.tag;

                //Adding points to the score depending on the object
                if (gameObject.CompareTag("Fungo")){
                    playerScore.AddPoints(fungoPoints);
                } else if (gameObject.CompareTag("Apple")){
                    playerScore.AddPoints(applePoints);
                }else if (gameObject.CompareTag("Rat")){
                    playerScore.AddPoints(ratPoints);
                }else if (gameObject.CompareTag("Lizard")){
                    playerScore.AddPoints(lizardPoints);
                }

                // Set the object's active state to false to make it disappear
                gameObject.SetActive(false);
            }
        }
    }
}
