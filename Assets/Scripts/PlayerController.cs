using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float currentVelocity; // new variable to keep track of current velocity
    public float velocityIncreaseAmount = 5f; // amount to increase velocity each time an object is collected


    private Rigidbody rb;
    public bool hasFallen = false;
    public float fallThreshold = -10f; 
    public int score = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();  
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); 

        rb.AddForce(movement * speed);

        if (transform.position.y < fallThreshold)
        {
            hasFallen = true;
        }

        currentVelocity = rb.velocity.magnitude; // update current velocity

    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("Score: " + score);


        speed += velocityIncreaseAmount; // increase speed by a certain amount
    }
}
