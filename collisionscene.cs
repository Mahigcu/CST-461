using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene switching

public class ChangeSceneOnDistance : MonoBehaviour
{
    public GameObject buttonObject; // Reference to the button object
    public float triggerDistance = 3f; // Distance to trigger the scene change
    public string sceneToLoad = "YourSceneName"; // The scene to load when the player gets close

    void Update()
    {
        // Check the distance between the player and the button object
        if (Vector3.Distance(transform.position, buttonObject.transform.position) < triggerDistance)
        {
            // Change the scene once the distance is less than the trigger distance
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}









