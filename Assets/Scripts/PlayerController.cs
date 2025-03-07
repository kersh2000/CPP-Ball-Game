using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;  // Base movement speed

    private Rigidbody ball; // Reference to rigibody
    
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        // Get directional input
        float verticalAxis = Input.GetAxis("Vertical"); // -1 to 1 of vertcal input (S to W)
        float horizontalAxis = Input.GetAxis("Horizontal"); // -1 to 1 of horizontal input (A to D)

        // Add force to rigid body
        ball.AddForce(speed * horizontalAxis, 0, speed * verticalAxis);
    }
}
