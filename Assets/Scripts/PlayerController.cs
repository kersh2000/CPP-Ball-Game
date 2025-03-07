using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;  // Base movement speed of the ball
    public float dragForce = 0.65f;  // Base drag to slow the ball down
    public int numOfPickups { get; private set; }
    public UnityEvent<PlayerController> OnPickupCollected;

    private Rigidbody ball; // Reference to ball's rigibody
    private Camera camera;  // Reference to the main camera
    
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        camera = Camera.main;
        // Add drag to ball properties
        ball.linearDamping = dragForce;

        //// Logs for debugging
        //InvokeRepeating("DebugLog", 0, 1);
    }
    
    void Update()
    {
        Move();
    }

    void Move()
    {
        // Get directional input
        float verticalAxis = Input.GetAxis("Vertical"); // -1 to 1 of vertcal input (S to W)
        float horizontalAxis = Input.GetAxis("Horizontal"); // -1 to 1 of horizontal input (A to D)

        // Find the vector from camera to input
        Vector3 direction = (camera.transform.TransformDirection(horizontalAxis, 0, verticalAxis));

        // Add force to ball
        ball.AddForce(speed * direction.x, 0, speed * direction.z);
    }

    public void Pickup()
    {
        numOfPickups++;
        OnPickupCollected.Invoke(this);
    }

    void DebugLog(string msg)
    {
        // Output ball's velocity
        Debug.Log(msg);
    }
}
