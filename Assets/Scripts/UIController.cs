using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private TextMeshProUGUI pickupText;
    void Start()
    {
        pickupText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdatePickupText(PlayerController player)
    {
        pickupText.text = player.numOfPickups.ToString();
    }
}
