using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public float remainingTime;

    private TextMeshProUGUI pickupText;
    private TextMeshProUGUI lifeText;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI timerText;
    private void Awake()
    {
        pickupText = GameObject.FindWithTag("Pickup").GetComponent<TextMeshProUGUI>();
        lifeText = GameObject.FindWithTag("Life").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
        timerText = GameObject.FindWithTag("Timer").GetComponent<TextMeshProUGUI>();
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

    public void UpdateTimerText(int seconds)
    {
        timerText.text = seconds.ToString();
    }
}