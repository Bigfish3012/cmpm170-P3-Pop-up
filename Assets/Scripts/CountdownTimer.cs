using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
// Reference: https://www.youtube.com/watch?v=POq1i8FyRyQ
public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timeRemaining = 60f;

    private bool isOver = false;

    void Update()
    {
        if (isOver)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining < 0f)
        {
            timeRemaining = 0f;
        }

        timerText.text = "Time: " + timeRemaining.ToString("0.0") + "s";

        if (timeRemaining <= 0f)
        {
            isOver = true;
            SceneManager.LoadScene(2);
        }
    }
}
