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
        ball = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get ball's direction
        Vector3 targetDirection = new Vector3(ball.linearVelocity.x, 0, ball.linearVelocity.z).normalized;

        // Delay the new direction vector 
        currentDirection = Vector3.Slerp(currentDirection, targetDirection, Time.deltaTime * turnSpeed);

        // Calcululate new camera position by adding the ball's position by the multiple of the change in direction by the offset (camera always behind the ball)
        Vector3 targetPosition = ball.position + Quaternion.LookRotation(targetDirection) * offset;

        // Transition to new position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * turnSpeed);

        // Look at center of ball for rotation
        transform.LookAt(ball.position);
    }
}