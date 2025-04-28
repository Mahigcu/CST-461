using UnityEngine;
using TMPro;
using System.Collections;

public class AnswerChecker : MonoBehaviour
{
    public TMP_InputField inputField; // Reference to the input field
    public TMP_Text feedbackText; // Reference to feedback text ("Try Again" or "Yayyy")
    private float displayTime = 1f; // Time to display "Try Again" message

    void Start()
    {
        // Ensure the feedbackText is hidden at the start
        if (feedbackText != null)
        {
            feedbackText.gameObject.SetActive(false); // Hide the feedback text initially
        }
    }

    public void CheckAnswer()
    {
        if (inputField == null || feedbackText == null)
        {
            Debug.LogError("Error: Some required components are missing.");
            return;
        }

        string userInput = inputField.text.Trim(); // Get input and trim spaces
        int playerAnswer;
        bool isValidNumber = int.TryParse(userInput, out playerAnswer);

        if (isValidNumber && playerAnswer == 4)
        {
            // Correct answer: Show "Yayyy" and hide "Try Again!"
            feedbackText.text = "Yayyy"; // Change to "Yayyy"
            feedbackText.gameObject.SetActive(true); // Show the text
        }
        else
        {
            // Incorrect answer: Show "Try Again!" for 1 second
            feedbackText.text = "Try!"; // Change to "Try Again!"
            feedbackText.gameObject.SetActive(true); // Show the text
            StartCoroutine(HideFeedbackMessage());
        }
    }

    private IEnumerator HideFeedbackMessage()
    {
        // Wait for the specified time before hiding the feedback message
        yield return new WaitForSeconds(displayTime);
        feedbackText.gameObject.SetActive(false); // Hide feedback text
    }
}





















