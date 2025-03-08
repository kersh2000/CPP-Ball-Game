using UnityEngine;

public class GoalController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            // Player has contacted the goal
            GameManagement.manager.NextScene();
        }
    }
}
