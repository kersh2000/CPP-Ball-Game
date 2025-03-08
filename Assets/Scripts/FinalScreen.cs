using UnityEngine;
using TMPro;

public class FinalScreen : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private void Awake()
    {
        scoreText = GameObject.FindWithTag("Score").GetComponent<TextMeshProUGUI>();
        int score = GameManagement.manager.score;
        if (score > GameManagement.manager.highestScore)
        {
            scoreText.text = "Final Score:\n" + GameManagement.manager.score.ToString() + "\n New Highest Score!!!";
            GameManagement.manager.highestScore = score;
        }
        else
        {
            scoreText.text = "Final Score:\n" + GameManagement.manager.score.ToString();
        }
    }
}