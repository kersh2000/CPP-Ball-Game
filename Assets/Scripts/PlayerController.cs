using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;  // Base movement speed of the ball
    public float dragForce = 0.65f;  // Base drag to slow the ball down

    private Rigidbody ball; // Reference to ball's rigibody
    private new Camera camera;  // Reference to the main camera
    private UIController UI;
    private CameraControlller cameraController;
    private float respawnThreshold;
    private Vector3 respawnPoint;

    void Start()
    {
        ball = GetComponent<Rigidbody>();
        camera = Camera.main;
        // Add drag to ball properties
        ball.linearDamping = dragForce;
        UI = FindFirstObjectByType<UIController>();
        cameraController = FindFirstObjectByType<CameraControlller>();
        respawnThreshold = GameObject.FindWithTag("Threshold").transform.position.y;
        respawnPoint = GameObject.FindWithTag("Spawn").transform.position;

        // Spawn player and camera at spawn location
        transform.position = respawnPoint;
        camera.transform.position = respawnPoint + cameraController.offset;

        UI.UpdateLifeText(GameManagement.manager.numOfLives);
        UI.UpdateScoreText(GameManagement.manager.score);
        UI.UpdatePickupText(GameManagement.manager.numOfPickups);

        //// Logs for debugging
        //InvokeRepeating("DebugLog", 0, 1);
    }

    void Update()
    {
        if (GameManagement.manager.numOfLives != 0)
        {
            Move();
        } 
        else
        {
            GameManagement.manager.LoadScene("Main Scene");
        }
    }

    void Move()
    {
        if (transform.position.y < respawnThreshold)
        {
            // Die and stop further function
            Die();
            return;
        }
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
        GameManagement.manager.IncreasePickup();
        UI.UpdateLifeText(GameManagement.manager.numOfLives);
        UI.UpdateScoreText(GameManagement.manager.score);
        UI.UpdatePickupText(GameManagement.manager.numOfPickups);
    }

    void Die()
    {
        GameManagement.manager.DecreaseLife();
        UI.UpdateLifeText(GameManagement.manager.numOfLives);
        UI.UpdateScoreText(GameManagement.manager.score);
        // Respawn
        transform.position = respawnPoint;
        // Resets forces and velocity
        ball.isKinematic = true;
        ball.isKinematic = false;
    }

    void DebugLog(string msg)
    {
        // Output ball's velocity
        Debug.Log(msg);
    }
}
