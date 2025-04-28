using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainCanvas;    // First screen
    public GameObject secondCanvas;  // Second screen

    void Start()
    {
        // Ensure only the main canvas is visible at the start
        mainCanvas.SetActive(true);
        secondCanvas.SetActive(false);
    }

    // Function to switch to the second screen
    public void ShowSecondCanvas()
    {
        mainCanvas.SetActive(false);
        secondCanvas.SetActive(true);
    }

    // Function to go back to the first screen
    public void ShowMainCanvas()
    {
        mainCanvas.SetActive(true);
        secondCanvas.SetActive(false);
    }
}

