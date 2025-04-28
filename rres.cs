using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeManager : MonoBehaviour
{
    public void ResumeGame()
    {
        if (PlayerPrefs.HasKey("LastScene"))
        {
            string lastScene = PlayerPrefs.GetString("LastScene"); // Retrieve the stored scene name
            SceneManager.LoadScene(lastScene); // Load the correct scene
        }
        else
        {
            Debug.LogError("No previous scene recorded.");
        }
    }
}

