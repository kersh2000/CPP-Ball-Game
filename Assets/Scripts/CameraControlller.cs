using UnityEngine;

public class CameraControlller : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 2.5f, -3.5f);    // Offset from ball

    private Rigidbody ball; // Reference to ball

    void Start()
    {
        // Fetch the balls rigid body by tag
        ball = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Add offset from ball's position
        transform.position = ball.position + offset;
    }
}
