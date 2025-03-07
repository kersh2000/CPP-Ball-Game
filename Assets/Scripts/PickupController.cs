using UnityEngine;

public class PickupController : MonoBehaviour
{
    private Transform childTransform;
    private void Start()
    {
        childTransform = transform.Find("Cherry");
    }

    private void Update()
    {
        childTransform.transform.Rotate(0, 180 * Time.deltaTime, 0);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            player.Pickup();
            gameObject.SetActive(false);
        }
    }
}
