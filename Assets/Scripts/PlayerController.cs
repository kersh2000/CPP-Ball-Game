using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;  // Base movement speed of the ball
    public float dragForce = 0.65f;  // Base drag to slow the ball down

    private Rigidbody ball; // Reference to ball's rigibody
    
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        // Add drag to ball properties
        ball.linearDamping = dragForce;

        //// Logs for debugging
        //InvokeRepeating("DebugLog", 0, 1);
    }
    
    void Update()
    {
        // Get directional input
        float verticalAxis = Input.GetAxis("Vertical"); // -1 to 1 of vertcal input (S to W)
        float horizontalAxis = Input.GetAxis("Horizontal"); // -1 to 1 of horizontal input (A to D)

        // Add force to ball
        ball.AddForce(speed * horizontalAxis, 0, speed * verticalAxis);
    }

    void DebugLog()
    {
        // Output ball's velocity
        Debug.Log("Velocity: " + ball.linearVelocity);
    }
}
