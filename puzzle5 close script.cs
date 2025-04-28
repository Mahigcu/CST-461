using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene switching

public class SceneTriggerOnProximity : MonoBehaviour
{
    public GameObject objectToApproach; // The object that needs to approach this object
    public float distanceThreshold = 3f; // The distance at which the scene will change
    public string targetScene = "Puzzle 5"; // The name of the scene to load when the objects are close

    void Update()
    {
        // Check the distance between this object and the objectToApproach
        if (Vector3.Distance(transform.position, objectToApproach.transform.position) < distanceThreshold)
        {
            // If the distance is less than the distanceThreshold, load the target scene
            SceneManager.LoadScene(targetScene);
        }
    }
}


