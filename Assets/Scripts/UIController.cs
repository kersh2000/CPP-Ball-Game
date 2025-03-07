using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private TextMeshProUGUI pickupText;
    private TextMeshProUGUI lifeText;
    private TextMeshProUGUI scoreText;
    void Start()
    {
        pickupText = GameObject.FindWithTag("Pickup").GetComponent<TextMeshProUGUI>();
        lifeText = GameObject.FindWithTag("Life").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
    }

    public void UpdatePickupText(int count)
    {
        pickupText.text = count.ToString();
    }

    public void UpdateLifeText(int lives)
    {
        lifeText.text = lives.ToString() + " Lives";
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}