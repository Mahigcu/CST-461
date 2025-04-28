using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // The sprite you want the camera to follow
    public Vector3 offset;     // Offset for the camera's position (close behind and above the sprite)
    public float smoothSpeed = 0.125f; // Smooth speed of the camera movement
    public float rotationSpeed = 5f;   // Speed at which the camera rotates when the sprite turns

    void LateUpdate()
    {
        // Calculate the desired position for the camera
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position
        transform.position = smoothedPosition;

        // Rotate the camera to face the sprite as it turns around
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}



