using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene switching

public class SceneChangeOnTouch : MonoBehaviour
{
    public string sceneToLoad = "YourSceneName"; // Set the target scene name in the Inspector or here

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            SceneManager.LoadScene(sceneToLoad); // Load the specified scene
        }
    }
}

