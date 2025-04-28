using UnityEngine;
using TMPro;

public class ScarabButton : MonoBehaviour
{
    [Header("Button Settings")]
    public TextMeshProUGUI buttonText;  // Text component
    public int hiddenNumber;  // Number to reveal
    private bool isClicked = false;  // Track button state

    void Start()
    {
        // Try to find the button text if not assigned
        if (buttonText == null)
        {
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText == null)
                Debug.LogError($"[{gameObject.name}] buttonText is missing! Assign it in the Inspector.");
        }

        // Hide the text initially
        if (buttonText != null) 
            buttonText.text = "";
    }

    public void RevealNumber()
    {
        if (!isClicked)
        {
            Debug.Log($"[{gameObject.name}] Button Clicked! Revealing Number...");

            // Null check before using buttonText
            if (buttonText == null)
            {
                Debug.LogError($"[{gameObject.name}] buttonText is null! Assign it in the Inspector.");
                return;
            }

            // Reveal the number
            buttonText.text = hiddenNumber.ToString();
            isClicked = true;
        }
    }
}








