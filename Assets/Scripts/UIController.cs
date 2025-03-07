using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private TextMeshProUGUI pickupText;
    private TextMeshProUGUI lifeText;
    void Start()
    {
        pickupText = GameObject.FindWithTag("Pickup").GetComponent<TextMeshProUGUI>();
        lifeText = GameObject.FindWithTag("Life").GetComponent<TextMeshProUGUI>();
    }

    public void UpdatePickupText(PlayerController player)
    {
        pickupText.text = player.numOfPickups.ToString();
    }

    public void UpdateLifeText(PlayerController player)
    {
        lifeText.text = player.numOfLives.ToString() + " Lives";
    }
}