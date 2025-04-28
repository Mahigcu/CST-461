using UnityEngine;

public class CustomCameraFollow : MonoBehaviour
{
    public Transform playerTransform;  // The sprite you want the camera to follow
    public Vector3 cameraOffset;       // Offset for the camera's position (close behind and above the sprite)
    public float moveSmoothSpeed = 0.125f;  // Smooth speed of the camera movement
    public float rotationSmoothSpeed = 5f;  // Speed at which the camera rotates when the sprite turns

    public Vector2 cameraMinBounds;    // Minimum boundary (left/bottom)
    public Vector2 cameraMaxBounds;    // Maximum boundary (right/top)

    void LateUpdate()
    {
        // Calculate the desired position for the camera based on the player’s position and the offset
        Vector3 targetPosition = playerTransform.position + cameraOffset;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, moveSmoothSpeed);

        // Clamp the camera position within the specified boundaries
        float clampedX = Mathf.Clamp(smoothedPosition.x, cameraMinBounds.x, cameraMaxBounds.x);
        float clampedY = Mathf.Clamp(smoothedPosition.y, cameraMinBounds.y, cameraMaxBounds.y);
        
        // Set the camera's position with the clamped values
        transform.position = new Vector3(clampedX, clampedY, smoothedPosition.z);

        // Rotate the camera to face the player as it turns around
        Quaternion targetRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothSpeed * Time.deltaTime);
    }
}






