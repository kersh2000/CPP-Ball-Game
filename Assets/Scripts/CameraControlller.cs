using TMPro;
using UnityEngine;

public class CameraControlller : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 2.5f, -3.5f);    // Offset from ball
    public float turnSpeed = 2.0f;

    private Rigidbody ball; // Reference to ball
    private Vector3 currentDirection = Vector3.forward;

    void Start()
    {
        // Fetch the balls rigid body by tag
        GameObject ballReference = GameObject.FindWithTag("Player");
        if (ballReference)
        {
            ball = ballReference.GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (ball != null)
        {
            // Get ball's direction
            Vector3 targetDirection = new Vector3(ball.linearVelocity.x, 0, ball.linearVelocity.z).normalized;

            // Delay the new direction vector 
            currentDirection = Vector3.Slerp(currentDirection, targetDirection, Time.deltaTime * turnSpeed);
            Vector3 targetPosition;

            if (targetDirection != Vector3.zero)
            {
                // Calcululate new camera position by adding the ball's position by the multiple of the change in direction by the offset (camera always behind the ball)
                targetPosition = ball.position + Quaternion.LookRotation(targetDirection) * offset;
            }
            else
            {
                targetPosition = ball.position + offset;
            }

            // Transition to new position
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * turnSpeed);

            // Look at center of ball for rotation
            transform.LookAt(ball.position);
        }
    }
}