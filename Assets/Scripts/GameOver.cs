using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI currentScoreText;

    private void Start()
    {
        // source from: https://www.youtube.com/watch?v=6PkdHcVFM6M
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore.ToString();

        int lastScore = PlayerPrefs.GetInt("LastScore", 0);
        currentScoreText.text = "Score: " + lastScore.ToString();


    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Home()
    {
        PlayerPrefs.DeleteKey("HighScore");
        SceneManager.LoadScene(0);
    }
}
