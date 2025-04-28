using UnityEngine;
using UnityEngine.SceneManagement;  // Needed for level transition

public class GameUIManager : MonoBehaviour
{
    public GameObject successPanel;  // Drag the Success panel in the Inspector
    public GameObject gameOverPanel; // Drag the Game Over panel in the Inspector

    void Start()
    {
        successPanel.SetActive(false);  // Initially, hide success panel
        gameOverPanel.SetActive(false);  // Initially, hide Game Over panel
    }

    // Call this function when the player gets the correct answer
    public void ShowSuccess()
    {
        successPanel.SetActive(true);  // Show the success panel when player succeeds
    }

    // Show the Game Over panel
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);  // This shows the Game Over panel
    }

    // Function to move to the next level
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Function to retry the current level
    public void Retry()
    {
        
        
         gameOverPanel.SetActive(false);
        
         ResetGame(); // Reloads the current scene
    }

private void ResetGame()
    {
        // Example: Reset player position, score, or any game objects
        // For instance:
        // player.transform.position = startPosition;
        // score = 0;
        // etc.
    }
}


