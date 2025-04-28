using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText; // TextMeshPro for the timer
    public TMP_Text scoreText; // TextMeshPro for the score
    public Button stopButton;  // Button to stop the timer

    private float elapsedTime = 0f;
    private bool isRunning = true;

    private int score = 20; // Start with 20 points

    void Start()
    {
        // Initialize timer and score
        elapsedTime = 0f;
        isRunning = true;
        UpdateScoreDisplay();

        // Attach the stop button event
        if (stopButton != null)
            stopButton.onClick.AddListener(StopTimer);
    }

    void Update()
    {
        if (isRunning)
        {
            // Increment time and update displays
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
            UpdateScore();
        }
    }

    void UpdateTimerDisplay()
    {
        // Format time as MM:SS
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void UpdateScore()
    {
        // Calculate the score based on time elapsed
        int timePenalty = Mathf.FloorToInt(elapsedTime / 5); // 1 point lost every 10s
        int newScore = 20 - timePenalty;

        // Prevent the score from going below zero
        newScore = Mathf.Max(newScore, 0);

        // Update only if the score has changed
        if (newScore != score)
        {
            score = newScore;
            UpdateScoreDisplay();
        }
    }

    void UpdateScoreDisplay()
    {
        // Update the score text
        scoreText.text = $"{score}";
    }

    public void StopTimer()
    {
        // Stop the timer when the button is clicked
        isRunning = false;
        Debug.Log($"Timer stopped at: {timerText.text}, Final Score: {score}");
    }
}





