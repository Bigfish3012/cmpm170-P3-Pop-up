using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int currentScore = 0;

    [SerializeField]private TextMeshProUGUI highScoreText;
    [SerializeField] private int highScore = 0;

    private void Awake()
    {
        Instance = this;

        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
        if (highScoreText != null)
        {
            if (currentScore > highScore)
            {
                highScore = currentScore;
            }
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}
