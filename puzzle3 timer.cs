using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerScoreManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI timerText;        // Display the timer (using TextMeshPro)
    public TextMeshProUGUI scoreText;        // Display the score (using TextMeshPro)
    public TMP_InputField inputField;       // TMP InputField to enter number
    public Button pressMeButton;            // Button to start the timer

    private float timer = 0f;                // Timer value
    private int score = 20;                  // Starting score
    private bool isTimerRunning = false;     // Timer running state
    private float timeSinceLastScoreDecrease = 0f; // Track time since the last score decrease

    private void Start()
    {
        // Initially set up UI
        timerText.text = "Time: 0s";
        scoreText.text = "" + score;

        // Add listener for the button
        pressMeButton.onClick.AddListener(StartTimer);
    }

    private void Update()
    {
        // If the timer is running, update the timer and score
        if (isTimerRunning)
        {
            timer += Time.deltaTime; // Increase timer by the time passed since the last frame
            int seconds = Mathf.FloorToInt(timer);

            // Update timer UI
            timerText.text = "Time: " + seconds + "s";

            // Track time since the last score decrease
            timeSinceLastScoreDecrease += Time.deltaTime;

            // Every 5 seconds, decrease the score by 1 point
            if (timeSinceLastScoreDecrease >= 5f)
            {
                if (score > 0) // Ensure score doesn't go below 0
                {
                    score--;  // Decrease score
                    scoreText.text = "" + score;
                }

                timeSinceLastScoreDecrease = 0f; // Reset the timer for score decrease
            }

            // Check if input value is 70, stop the timer and the score
            if (inputField.text == "70")
            {
                StopTimer();
            }
        }
    }

    // Function to start the timer when the button is pressed
    private void StartTimer()
    {
        isTimerRunning = true;
    }

    // Function to stop the timer
    private void StopTimer()
    {
        isTimerRunning = false;
        timerText.text = "Time: " + Mathf.FloorToInt(timer) + "s (Stopped)";
        scoreText.text = "" + score;
    }
}




