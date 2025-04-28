using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public void PauseGame()
    {
        string currentScene = SceneManager.GetActiveScene().name; // Get current scene name
        PlayerPrefs.SetString("LastScene", currentScene); // Save it using PlayerPrefs
        PlayerPrefs.Save(); // Make sure it is stored
        SceneManager.LoadScene("Welcome Page"); // Load the Pause Menu scene
    }
}
