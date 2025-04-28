using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_InputField inputField; // Input field for user input
    public TMP_Text timerText;        // Text to display timer
    public TMP_Text scoreText;        // Text to display score

    private float timeElapsed = 0f;   // Timer starts from 0
    private int score = 20;           // Initial score
    private bool isRunning = true;

    void Start()
    {
        // Add a listener to the input field when Submit/Enter is pressed
        inputField.onEndEdit.AddListener(CheckInput);
    }

    void Update()
    {
        if (isRunning)
        {
            // Increase timer continuously
            timeElapsed += Time.deltaTime;

            // Every 5 seconds, reduce the score by 1
            if (Mathf.FloorToInt(timeElapsed) % 5 == 0 && timeElapsed > 0)
            {
                int pointsLost = Mathf.FloorToInt(timeElapsed / 5);
                score = Mathf.Max(0, 20 - pointsLost);
            }

            UpdateUI();
        }
    }

    // Check if input is 4 when submit is pressed
    void CheckInput(string input)
    {
        if (input.Trim() == "4")
        {
            StopGame();
        }

        // Clear the input field regardless of correct or incorrect entry
        inputField.text = "";
    }

    // Stop the timer and score
    void StopGame()
    {
        isRunning = false;
        Debug.Log("Correct answer! Timer and score stopped.");
    }

    // Update the timer and score display
    void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
        scoreText.text = $"{score}";
    }
}






